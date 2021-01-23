    static class ModelExtension
    {   
        public static dynamic GetColModel(this Model model, string colName, int colWidth, string additonalProperties) {
            dynamic expando = new ExpandoObject();
            var json = JsonConvert.DeserializeObject<JObject>(additonalProperties);
            expando.name = colName;
            expando.width = colWidth;
            return new FromPropertiesDynamicObjectCreator(expando, json);
        }
        private class FromPropertiesDynamicObjectCreator : DynamicObject
        {
            private readonly dynamic expando = null;
            public FromPropertiesDynamicObjectCreator(IDictionary<string, object> expando, JObject props = null) {
                this.expando = expando;
                if (props != null) {
                    ((dynamic)this).props = props;
                }
            }
            public override bool TrySetMember(SetMemberBinder binder, object value) {
                if (binder.Name.Equals("props")) {
                    var jsonObj = value as JObject;
                    JToken current = jsonObj.First;
                    var dictionary = expando as IDictionary<string, object>;
                    RecurseJson(current, dictionary);
                    return true;
                }
                return false;
            }
            private void RecurseJson(JToken current, IDictionary<string, object> dictionary) {
                JToken value;
                Dictionary<string, object> newDictionary;
                while (current != null) {
                    var children = current.Children().ToList();
                    foreach (var child in children) {
                        switch (child.Type) {
                            case JTokenType.Object:
                            case JTokenType.Array:
                                newDictionary = new Dictionary<string, object>();
                                dictionary[child.Path] = newDictionary;
                                RecurseJson(child, newDictionary);
                                break;
                            case JTokenType.Property:
                                var prop = ((JProperty)child);
                                value = prop.Value;
                                if (value.HasValues) {
                                    newDictionary = new Dictionary<string, object>();
                                    dictionary[prop.Name] = newDictionary;
                                    RecurseJson(child, newDictionary);
                                    break;
                                }
                                dictionary[prop.Name] = ((dynamic)value).Value;
                                break;
                            default:
                                var val = ((dynamic)child).Value;
                                if (val is JToken) {
                                    dictionary[child.Path] = val.Value;
                                }
                                else {
                                    dictionary[child.Path] = val;
                                }
                                break;
                        }
                    }
                    current = current.Next;
                }
            }
            public override bool TryGetMember(GetMemberBinder binder, out object result) {
                object value;
                var dictionary = expando as IDictionary<string, object>;
                if (dictionary.TryGetValue(binder.Name, out value)) {
                    var innerDictionary = value as IDictionary<string, object>;
                    if (innerDictionary != null) {
                        result = new FromPropertiesDynamicObjectCreator(innerDictionary);
                    }
                    else {
                        result = value;
                    }
                    return true;
                }
                result = null;
                return true;
            }
        }
    }
