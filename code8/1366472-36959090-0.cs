        JArray parsedArray = JArray.Parse(jsonString);
            foreach (JObject parsedObject in parsedArray.Children<JObject>())
            {
                foreach (JProperty parsedProperty in parsedObject.Properties())
                {
                    string propertyName = parsedProperty.Name;
                    if (propertyName.Equals("p"))
                    {
                        string propertyValue = (string)parsedProperty.Value;
                        Console.WriteLine("Name: {0}, Value: {1}", propertyName, propertyValue);
                    }
                }
            }
