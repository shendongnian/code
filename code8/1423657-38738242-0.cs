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
                var filterTokenContainer = JToken.Parse(jsonFilter) as JContainer;
                JToken outputToken = JToken.Parse(targetData);
                List<string> fieldsToBePreserved = new List<string>();
                GetFlattenedPropertyList(filterTokenContainer, ref fieldsToBePreserved);
                removeFields(outputToken, fieldsToBePreserved);
                return outputToken;
            }
    
            private static void GetFlattenedPropertyList(JContainer inputTokenContainer, ref List<string> fieldsToBePreserved)
            {
                foreach (JToken el in inputTokenContainer.Children())
                {
                    JProperty p = el as JProperty;
                    if (p.Type == JTokenType.Array)
                    {
                        GetFlattenedPropertyList(p as JContainer, ref fieldsToBePreserved);
                    }
                    else
                    {
                        fieldsToBePreserved.Add(p.Name);
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
