        public static IEnumerable<T> OrderByField<T>(this IEnumerable<T> list, string sortExpression)
        {
            sortExpression += "";
            string[] parts = sortExpression.Split(' ');
            bool descending = false;
            string fullProperty = "";
            if (parts.Length > 0 && parts[0] != "")
            {
                fullProperty = parts[0];
                if (parts.Length > 1)
                {
                    descending = parts[1].ToLower().Contains("esc");
                }
                string fieldName;
                PropertyInfo parentProp = null;
                PropertyInfo prop = null;
                if (fullProperty.Contains("."))
                {
                    // A nested property
                    var parentProperty = fullProperty.Remove(fullProperty.IndexOf("."));
                    fieldName = fullProperty.Substring(fullProperty.IndexOf("."));
                    parentProp = typeof(T).GetProperty(parentProperty);
                    prop = parentProp.PropertyType.GetProperty(fieldName);
                }
                else
                {
                    // A simple property
                    prop = typeof(T).GetProperty(fullProperty);
                }
                if (prop == null)
                {
                    throw new Exception("No property '" + fullProperty + "' in + " + typeof(T).Name + "'");
                }
                if (parentProp != null)
                {
                    if (descending)
                        return list.OrderByDescending(x => prop.GetValue(parentProp.GetValue(x, null), null));
                    else
                        return list.OrderBy(x => prop.GetValue(parentProp.GetValue(x, null), null));
                }
                else
                {
                    if (descending)
                        return list.OrderByDescending(x => prop.GetValue(x, null));
                    else
                        return list.OrderBy(x => prop.GetValue(x, null));
                }
            }
            return list;
        }
