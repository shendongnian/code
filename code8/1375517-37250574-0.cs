    class PersionDateNamingConvention : IStoreModelConvention<EdmProperty>
    {
        public void Apply(EdmProperty property, DbModel model)
        {
            if (property.TypeName == "bigint" && property.Name.EndsWith("_Value"))
            {
                property.Name = property.Name.Replace("_Value", "_PersianDate");
            }
        }
    }
