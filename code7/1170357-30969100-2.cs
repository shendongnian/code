    JObject jsonObject = JObject.Parse(json);
                IList<JToken> results = jsonObject["listings"]["data"].Children().ToList();
    
                IList<Property> processedList = new List<Property>();
                foreach (JToken item in results)
                {
                    Property propertyItem = JsonConvert.DeserializeObject<Property>(item.ToString());
                    processedList.Add(propertyItem);
                }
