        public Dictionary<string, string> ComplexJsonToDictionary(JObject jObject, Dictionary<string, string> result, string field)
        {
            foreach (var property in jObject.Properties())
            {
                var endField = field + (string.IsNullOrEmpty(field) ? "" : "_") + property.Name;
                var innerDictionary = new Dictionary<string, string>();
                try
                {
                    var innerValue = JObject.Parse(Convert.ToString(property.Value));
                    result.AddOrOverride(ComplexJsonToDictionary(innerValue, innerDictionary, endField));
                }
                catch (Exception)
                {
                    try
                    {
                        var innerValues = JArray.Parse(Convert.ToString(property.Value));
                        try
                        {
                            var i = 0;
                            foreach (var token in innerValues)
                            {
                                var innerValue = JObject.Parse(Convert.ToString(token));
                                result.AddOrOverride(ComplexJsonToDictionary(innerValue, innerDictionary, endField+i++));
                            }
                        }
                        catch (Exception)
                        {
                            result.Add(endField, string.Join(",", innerValues.Values<string>()));
                        }
                    }
                    catch (Exception)
                    {
                        result.Add(endField, property.Value.ToString());
                    }
                }
            }
            return result;
        }
