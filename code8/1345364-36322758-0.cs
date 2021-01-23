    public enum AttributeTypes
    {
        TypeA, TypeB
    }
    public class ReferencesEnumAttribute : Attribute
    {
        public AttributeTypes AttributeType { get; set; }
        public ReferencesEnumAttribute(AttributeTypes attributeType)
        {
            AttributeType = attributeType;
        }
    }
    public class FindsClassesByAttributeAndEnumValue
    {
        public Type[] FindClassesInAssemblyContaining<T>(AttributeTypes attributeType)
        {
            return typeof (T).Assembly.GetTypes()
                .Where(type => type.GetCustomAttributes(false)
                    .Any(attribute => attribute is ReferencesEnumAttribute
                      && ((ReferencesEnumAttribute) attribute).AttributeType == attributeType))
                .ToArray();
        }
    }
