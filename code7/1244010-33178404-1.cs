            var obj = JObject.Parse(jsonString);
            foreach (var value in obj.Descendants().OfType<JValue>().Where(v => v.Type == JTokenType.String && (string)v == "(null)").ToList())
            {
                if (value.Parent.Type == JTokenType.Property)
                    value.Parent.Remove(); // Psuedo null-valued object property.  Remove the property.
                else
                    value.Replace(JValue.CreateNull()); // Psuedo null-valued array entry.  Replace with null to avoid reindexing the array.
            }
            var myClass = obj.ToObject<MyClass>();
