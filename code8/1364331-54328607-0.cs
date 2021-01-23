internal sealed class MvcActionValueBinder : DefaultActionValueBinder
{
	private static readonly Type stringType = typeof(string);
	// Per-request storage, uses the Request.Properties bag. We need a unique key into the bag.
	private const string Key = "5DC187FB-BFA0-462A-AB93-9E8036871EC8";
	private readonly JsonSerializerSettings serializerSettings;
	public MvcActionValueBinder(JsonSerializerSettings serializerSettings)
	{
		this.serializerSettings = serializerSettings;
	}
	public override HttpActionBinding GetBinding(HttpActionDescriptor actionDescriptor)
	{
		var actionBinding = new MvcActionBinding(serializerSettings);
		HttpParameterDescriptor[] parameters = actionDescriptor.GetParameters().ToArray();
		HttpParameterBinding[] binders = Array.ConvertAll(parameters, DetermineBinding);
		actionBinding.ParameterBindings = binders;
		return actionBinding;
	}
	private HttpParameterBinding DetermineBinding(HttpParameterDescriptor parameter)
	{
		HttpConfiguration config = parameter.Configuration;
		var attr = new ModelBinderAttribute(); // use default settings
		ModelBinderProvider provider = attr.GetModelBinderProvider(config);
		IModelBinder binder = provider.GetBinder(config, parameter.ParameterType);
		// Alternatively, we could put this ValueProviderFactory in the global config.
		var valueProviderFactories = new List<ValueProviderFactory>(attr.GetValueProviderFactories(config)) { new BodyValueProviderFactory() };
		return new ModelBinderParameterBinding(parameter, binder, valueProviderFactories);
	}
	// Derive from ActionBinding so that we have a chance to read the body once and then share that with all the parameters.
	private class MvcActionBinding : HttpActionBinding
	{
		private readonly JsonSerializerSettings serializerSettings;
		public MvcActionBinding(JsonSerializerSettings serializerSettings)
		{
			this.serializerSettings = serializerSettings;
		}
		// Read the body upfront, add as a ValueProvider
		public override Task ExecuteBindingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
		{
			HttpRequestMessage request = actionContext.ControllerContext.Request;
			HttpContent content = request.Content;
			if (content != null)
			{
				string result = request.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrEmpty(result))
				{
					var jsonContent = JObject.Parse(result);
					var values = new Dictionary<string, object>();
					foreach (HttpParameterDescriptor parameterDescriptor in actionContext.ActionDescriptor.GetParameters())
					{
						object parameterValue = GetParameterValue(jsonContent, parameterDescriptor);
						values.Add(parameterDescriptor.ParameterName, parameterValue);
					}
					IValueProvider valueProvider = new NameValuePairsValueProvider(values, CultureInfo.InvariantCulture);
					request.Properties.Add(Key, valueProvider);
				}
			}
			return base.ExecuteBindingAsync(actionContext, cancellationToken);
		}
		private object GetParameterValue(JObject jsonContent, HttpParameterDescriptor parameterDescriptor)
		{
			string propertyValue = jsonContent.Property(parameterDescriptor.ParameterName)?.Value.ToString();
			if (IsSimpleParameter(parameterDescriptor))
			{
				// No deserialization needed for value type, a cast is enough
				return Convert.ChangeType(propertyValue, parameterDescriptor.ParameterType);
			}
			return JsonConvert.DeserializeObject(propertyValue, parameterDescriptor.ParameterType, serializerSettings);
		}
		private bool IsSimpleParameter(HttpParameterDescriptor parameterDescriptor)
		{
			return parameterDescriptor.ParameterType.IsValueType || parameterDescriptor.ParameterType == stringType;
		}
	}
	// Get a value provider over the body. This can be shared by all parameters.
	// This gets the values computed in MvcActionBinding.
	private class BodyValueProviderFactory : ValueProviderFactory
	{
		public override IValueProvider GetValueProvider(HttpActionContext actionContext)
		{
			actionContext.Request.Properties.TryGetValue(Key, out object vp);
			return (IValueProvider)vp; // can be null 
		}
	}
}
To explain, the trick is to first read the request content as a `string` and then loading it into a `JObject`. 
For each parameter present in `actionContext.ActionDescriptor` a dictionnary is populated with the parameter name as key and we use the parameter type to add the object value.
Depending on the parameter type we either do a simple cast or use Json.NET to deserialize the value into the desired type. 
In my example, I pass around a `JsonSerializerSettings` because I have some custom converters that I want to use, be you may not need it.
