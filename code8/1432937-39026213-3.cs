    public static DataParamAttribute GetDataParameterAttribute(this PropertyInfo propertyInfo)
            {
                DataParamAttribute mappedAttribute = null;
    
                // Get list of Custom Attributes on a property
                var attributeArray = propertyInfo.GetCustomAttributes(false);
    
                // Column mapping of the ParameterAttribute
                var columnMapping =
                    attributeArray.FirstOrDefault(attribute => attribute.GetType() == typeof(DataParamAttribute));
    
                if (columnMapping != null)
                {
                    // Typecast to get the mapped attribute
                    mappedAttribute = columnMapping as DataParamAttribute;
                }
                return mappedAttribute;
            }
 
