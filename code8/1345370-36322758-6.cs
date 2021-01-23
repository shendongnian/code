    public class FindsClassesByAttributeAndEnumValue
    {
        public Type[] FindClassesInAssemblyContaining<TContains,TInheritsFrom>(AttributeTypes attributeType)
            where TInheritsFrom : class
        {
            return typeof (TContains).Assembly.GetTypes()
                .Where(type => 
                    type.IsAssignableFrom(typeof(TInheritsFrom))
                    && type.GetCustomAttributes(false)
                    .Any(attribute => attribute is ReferencesEnumAttribute
                                      && ((ReferencesEnumAttribute) attribute).AttributeType == attributeType))
                .ToArray();
        }
    }
