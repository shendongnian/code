	[ODataRouting]
	[CustomODataFormatting]
	public class MyController : ApiController
	{
		...
	}
	public class CustomODataFormattingAttribute : ODataFormattingAttribute
	{
		public override IList<System.Web.OData.Formatter.ODataMediaTypeFormatter> CreateODataFormatters()
		{
			return System.Web.OData.Formatter.ODataMediaTypeFormatters.Create(
				new CustomODataSerializerProvider(),
				new System.Web.OData.Formatter.Deserialization.DefaultODataDeserializerProvider());
		}
	}
