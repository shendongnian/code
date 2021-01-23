    class NameValueCollectionMapper<T> where T : new() {
        private static readonly Regex _regex = new Regex(@"\[(?<value>.*?)\]", RegexOptions.Compiled | RegexOptions.Singleline);
        public static T Map(NameValueCollection nvc, string rootObjectName) {
            var result = new T();
            foreach (string kvp in nvc.AllKeys) {
                if (!kvp.StartsWith(rootObjectName))
                    throw new Exception("All keys should start with " + rootObjectName);                                
                var match = _regex.Match(kvp.Remove(0, rootObjectName.Length));
                
                if (match.Success) {
                    // build path in a form of [Documents, 0, DocumentID]-like array
                    var path = new List<string>();
                    while (match.Success) {
                        path.Add(match.Groups["value"].Value);
                        match = match.NextMatch();
                    }
                    // this is object we currently working on                                      
                    object currentObject = result;                    
                    for (int i = 0; i < path.Count; i++) {
                        bool last = i == path.Count - 1;
                        var propName = path[i];
                        int index;
                        if (int.TryParse(propName, out index)) {
                            // index access, like [0]
                            var list = currentObject as IList;
                            if (list == null)
                                throw new Exception("Invalid index access expression"); // more info here
                            // get the type of item in that list (i.e. Document)
                            var args = list.GetType().GetGenericArguments();
                            var listItemType = args[0];                            
                            if (last)
                            {
                                // may need more sophisticated conversion from string to target type
                                list[index] = Convert.ChangeType(nvc[kvp], Nullable.GetUnderlyingType(listItemType) ?? listItemType);
                            }
                            else
                            {
                                // if not initialized - initalize
                                var next = index < list.Count ? list[index] : null;
                                if (next == null)
                                {
                                    // handle IList case in a special way here, since you cannot create instance of interface                                    
                                    next = Activator.CreateInstance(listItemType);
                                    // fill with nulls if not enough items yet
                                    while (index >= list.Count) {
                                        list.Add(null);
                                    }
                                    list[index] = next;
                                }
                                currentObject = next;
                            }                                                        
                        }
                        else {
                            var prop = currentObject.GetType().GetProperty(propName, BindingFlags.Instance | BindingFlags.Public);
                            if (last) {
                                // may need more sophisticated conversion from string to target type
                                prop.SetValue(currentObject, Convert.ChangeType(nvc[kvp], Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType));
                            }
                            else {
                                // if not initialized - initalize
                                var next = prop.GetValue(currentObject);
                                if (next == null) {
                                    // TODO: handle IList case in a special way here, since you cannot create instance of interface                                    
                                    next = Activator.CreateInstance(prop.PropertyType);
                                    prop.SetValue(currentObject, next);
                                }
                                currentObject = next;
                            }                            
                        }
                    }
                }                   
            }
            return result;
        }
    }
