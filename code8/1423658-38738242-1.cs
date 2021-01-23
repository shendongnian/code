            static void Main(string[] args)
            {
                var inputRequest = "{\"Id\":\"\",\"Wells\":[{\"WellNumber\":\"\"}],\"ExternalKey\":\"\"}";
                var valueObtainedFromDb =
                    "[{\"Id\": \"J.16.002219\",\"Wells\": [{\"WellNumber\": \"63000008\",\"WellName\": \"Well One Desc\",\"ExternalKey\": \"ZW\",\"Job_Id\": \"J.16.002219\",\"HoleSections\": null}],\"ExternalKey\": null}]";
                var filteredOutput = GetOnlyRequestedData(inputRequest, valueObtainedFromDb);
                Console.WriteLine(filteredOutput);
            }
    
            private static JToken GetOnlyRequestedData(string jsonFilter, string targetData)
            {
                var jObject = JObject.Parse(jsonFilter);
                JToken outputToken = JToken.Parse(targetData);
                List<string> fieldsToBePreserved = new List<string>();
                GetFlattenedPropertyList(jObject, ref fieldsToBePreserved);
                removeFields(outputToken, fieldsToBePreserved);
                return outputToken;
            }
        private static void GetFlattenedPropertyList(JObject jObject, ref List<string> fieldsToBePreserved)
        {
            foreach (JProperty property in jObject.Properties())
            {
                if (property.Value.Type != JTokenType.Array)
                {
                    fieldsToBePreserved.Add(property.Name);
                }
                else
                {
                    fieldsToBePreserved.Add(property.Name);
                    var jArray = property.Value as JArray;
                    foreach (var element in jArray)
                    {
                        var v = JObject.Parse(element.ToString());
                        GetFlattenedPropertyList(v, ref fieldsToBePreserved);
                    }
                }
            }
        }
    
            private static void removeFields(JToken token, List<string> fields)
            {
                JContainer container = token as JContainer;
                if (container == null) return;
    
                List<JToken> removeList = new List<JToken>();
                foreach (JToken el in container.Children())
                {
                    JProperty p = el as JProperty;
                    if (p != null && !fields.Contains(p.Name))
                    {
                        removeList.Add(el);
                    }
                    removeFields(el, fields);
                }
    
                foreach (JToken el in removeList)
                {
                    el.Remove();
                }
    
               
            }
