    private string GetValue(object item, string propString)
        {
            if (item != null)
            {
                if (!string.IsNullOrEmpty(propString))
                {
                    try
                    {
                        var property = GetProperty(item.GetType().GetTypeInfo(), AutoCompleteSourceMember);
                        if (property != null)
                        {
                            var value = property.GetValue(item);
                            if (value != null)
                            {
                                return value.ToString();
                            }
                        }
                        return string.Empty;
                    }
                    catch (Exception ex)
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    return item.ToString();
                }
            }
            return string.Empty;
        }
        private static PropertyInfo GetProperty(TypeInfo typeInfo, string propertyName)
        {
            var propertyInfo = typeInfo.GetDeclaredProperty(propertyName);
            if (propertyInfo == null && typeInfo.BaseType != null)
            {
                propertyInfo = GetProperty(typeInfo.BaseType.GetTypeInfo(), propertyName);
            }
            return propertyInfo;
        }
