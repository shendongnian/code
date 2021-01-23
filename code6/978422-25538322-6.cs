	public class CustomODataEntityTypeSerializer : System.Web.OData.Formatter.Serialization.ODataEntityTypeSerializer
	{
		public CustomODataEntityTypeSerializer(ODataSerializerProvider provider)
			: base(provider) { }
		public override ODataProperty CreateStructuralProperty(IEdmStructuralProperty structuralProperty, EntityInstanceContext entityInstanceContext)
		{
			var property = base.CreateStructuralProperty(structuralProperty, entityInstanceContext);
			return property.Value != null ? property : null;
		}
	}
