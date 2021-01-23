    public class JSONParamBindingAttribute : Attribute
	{
	}
	public class JSONParamBinding : HttpParameterBinding
	{
		private static JsonSerializer _serializer = JsonSerializer.Create(new JsonSerializerSettings()
		{
			DateTimeZoneHandling = DateTimeZoneHandling.Utc
		});
		public JSONParamBinding(HttpParameterDescriptor descriptor)
			: base(descriptor)
		{
		}
		public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
													HttpActionContext actionContext,
													CancellationToken cancellationToken)
		{
			JObject jobj = GetJSONParameters(actionContext.Request);
			object value = null;
			JToken jTokenVal = null;
			if (!jobj.TryGetValue(Descriptor.ParameterName, out jTokenVal))
			{
				if (Descriptor.IsOptional)
					value = Descriptor.DefaultValue;
				else
					throw new MissingFieldException("Missing parameter : " + Descriptor.ParameterName);
			}
			else
			{
				try
				{
					value = jTokenVal.ToObject(Descriptor.ParameterType, _serializer);
				}
				catch (Newtonsoft.Json.JsonException e)
				{
					throw new HttpParseException(String.Join("", "Unable to parse parameter: ", Descriptor.ParameterName, ". Type: ", Descriptor.ParameterType.ToString()));
				}
			}
			// Set the binding result here
			SetValue(actionContext, value);
			// now, we can return a completed task with no result
			TaskCompletionSource<AsyncVoid> tcs = new TaskCompletionSource<AsyncVoid>();
			tcs.SetResult(default(AsyncVoid));
			return tcs.Task;
		}
		public static HttpParameterBinding HookupParameterBinding(HttpParameterDescriptor descriptor)
		{
			if (descriptor.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<JSONParamBindingAttribute>().Count == 0 
				&& descriptor.ActionDescriptor.GetCustomAttributes<JSONParamBindingAttribute>().Count == 0)
				return null;
			var supportedMethods = descriptor.ActionDescriptor.SupportedHttpMethods;
			if (supportedMethods.Contains(HttpMethod.Post) || supportedMethods.Contains(HttpMethod.Get))
			{
				return new JSONParamBinding(descriptor);
			}
			return null;
		}
		private JObject GetJSONParameters(HttpRequestMessage request)
		{
			JObject jobj = null;
			object result = null;
			if (!request.Properties.TryGetValue("ParamsJSObject", out result))
			{
				if (request.Method == HttpMethod.Post)
				{
					jobj = JObject.Parse(request.Content.ReadAsStringAsync().Result);
				}
				else if (request.RequestUri.Query.StartsWith("?%7B"))
				{
					jobj = JObject.Parse(HttpUtility.UrlDecode(request.RequestUri.Query).TrimStart('?'));
				}
				else
				{
					jobj = new JObject();
					foreach (var kvp in request.GetQueryNameValuePairs())
					{
						jobj.Add(kvp.Key, JToken.Parse(kvp.Value));
					}
				}
				request.Properties.Add("ParamsJSObject", jobj);
			}
			else
			{
				jobj = (JObject)result;
			}
			return jobj;
		}
		private struct AsyncVoid
		{
		}
    }
