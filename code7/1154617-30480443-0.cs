            var values = new List<KeyValuePair<string, object>();
            PropertyInfo[] properties = typeof(ValidationResultAttribute).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                values.Add(property.Name, property.GetValue(res, null);
            }
            foreach(var value in values)
            {
                var length = Math.Max(value.Key.Length, value.Value.ToString().Length);
                var format = "{0,-" + length.ToString() + "} ";
                sw.Write(format, value.Key);
            }
            sw.WriteLine();
            foreach(var value in values)
            {
                var length = Math.Max(value.Key.Length, value.Value.ToString().Length);
                var format = "{0,-" + length.ToString() + "} ";
                sw.Write(format, value.Value);
            }
            sw.WriteLine();
