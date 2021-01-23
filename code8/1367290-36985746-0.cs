	using System;
	using System.Linq;
	using Newtonsoft.Json.Serialization;
	using Microsoft.AspNet.Mvc.Filters;
	using Newtonsoft.Json;
	using Microsoft.AspNet.Mvc.Formatters;
	
	namespace Teedl.Web.Infrastructure
	{
		[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	
		public class MobileControllerConfiguratorAttribute : Attribute, IResourceFilter
		{
			private readonly JsonSerializerSettings serializerSettings;
	
			public MobileControllerConfiguratorAttribute()
			{
				serializerSettings = new JsonSerializerSettings()
				{
					ContractResolver = new CamelCasePropertyNamesContractResolver(),
					TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects,
					TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
					Binder = new TypeNameSerializationBinder("Teedl.Model.Mobile.{0}, Teedl.Model.ClientMobile")
			};
			}
	
	
			public void OnResourceExecuted(ResourceExecutedContext context)
			{
			}
	
			public void OnResourceExecuting(ResourceExecutingContext context)
			{
				var mobileInputFormatter = new JsonInputFormatter(serializerSettings);
				var inputFormatter = context.InputFormatters.FirstOrDefault(frmtr => frmtr is JsonInputFormatter);
				if (inputFormatter != null)
				{
					context.InputFormatters.Remove(inputFormatter);
				}
				context.InputFormatters.Add(mobileInputFormatter);
	
				var mobileOutputFormatter = new JsonOutputFormatter(serializerSettings);
				var outputFormatter = context.OutputFormatters.FirstOrDefault(frmtr => frmtr is JsonOutputFormatter);
				if (outputFormatter != null)
				{
					context.OutputFormatters.Remove(outputFormatter);
				}
				context.OutputFormatters.Add(mobileOutputFormatter);
			}
		}
	}
