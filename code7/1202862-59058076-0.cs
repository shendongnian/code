	using System;
	using System.IO;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc.Formatters;
	namespace AspExtensions // or whatever
	{
		// see: https://stackoverflow.com/a/47807117/264031
		public class RawStringBodyInputFormatter : InputFormatter
		{
			public RawStringBodyInputFormatter()
			{
				this.SupportedMediaTypes.Add("text/plain");
				this.SupportedMediaTypes.Add("application/json");
			}
			public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
			{
				var request = context.HttpContext.Request;
				using(var reader = new StreamReader(request.Body)) {
					string content = await reader.ReadToEndAsync();
					return await InputFormatterResult.SuccessAsync(content);
				}
			}
			protected override bool CanReadType(Type type)
			{
				return type == typeof(string);
			}
		}
	}
