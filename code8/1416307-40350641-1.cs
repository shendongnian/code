	public class MyValueProviderFactory : IValueProviderFactory
	{
		private readonly IEnumerable<KeyValuePair<string,string>> keyMap;
		public MyValueProviderFactory(IConfigurationSection section)
		{
			keyMap = section.AsEnumerable();
		}
		public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}
			if (context.ActionContext.HttpContext.Request.HasFormContentType)
			{
				return AddValueProviderAsync(context, keyMap);
			}
			return TaskCache.CompletedTask;
		}
		private static async Task AddValueProviderAsync(ValueProviderFactoryContext context, IEnumerable<KeyValuePair<string, string>> keyMap)
		{
			var request = context.ActionContext.HttpContext.Request;
			var valueProvider = new MyValueProvider(
					BindingSource.Form,
					await request.ReadFormAsync(),
					keyMap,
					CultureInfo.CurrentCulture);
			context.ValueProviders.Add(valueProvider);
		}
	}
