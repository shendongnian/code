        public static string GetXML<T>(this List<T> src)
        {
            // First, we have to determine the "Type" of the generic parameter.
            Type srcType = src.GetType();
            Type[] srcTypeGenArgs = srcType.GetGenericArguments();
            if (srcTypeGenArgs.Length != 1)
                throw new Exception("Only designed to work on classes with a single generic param.");
            Type genType = srcTypeGenArgs[0];
            // Get the properties for the generic Type "T".
            System.Reflection.PropertyInfo[] typeProps = genType.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.GetProperty);
            // Now, we loop through each item in the list and extract the property values.
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<root>");
            for (int i = 0; i < src.Count; i++)
            {
                T listItem = src[i];
                for (int t = 0; t < typeProps.Length; t++)
                {
                    object propVal = typeProps[t].GetValue(listItem, null); // Always pass "null" for the index param, if we're not dealing with some indexed type (like an array).
                    string propValStr = (propVal != null ? propVal.ToString() : string.Empty);
                    sb.AppendLine(string.Format("<{0}>{1}</{0}>", typeProps[t].Name, propValStr));
                }
            }
            sb.AppendLine("</root>");
            return sb.ToString();
        }
