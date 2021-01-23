    public class CustomEntitySerializer : ODataEntityTypeSerializer
    {
        public CustomEntitySerializer(ODataSerializerProvider serializerProvider) : base(serializerProvider) {    }
        public override ODataEntry CreateEntry(SelectExpandNode selectExpandNode, EntityInstanceContext entityInstanceContext)
        {
            ODataEntry entry = base.CreateEntry(selectExpandNode, entityInstanceContext);           
            Request item = entityInstanceContext.EntityInstance as Request;
            if (entry != null && item != null)
            {
                // add your "NotMapped" property here.
                entry.Properties = new List<ODataProperty>(entry.Properties) { new ODataProperty { Name = "UserName", Value = item.UserName} };
            }
            return entry;
        }
    }
