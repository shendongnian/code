    public object GetPropertyValueFromPath(object baseObject, string path)
        {
            //Split into the base path elements
            string[] pp = CorrectPathForDictionaries(path).Split(new[]{ '.' }, StringSplitOptions.RemoveEmptyEntries);
            //Set initial value of the ValueObject
            object valueObject = baseObject;            
            foreach (var prop in pp)
            {
                if (prop.Contains("["))
                {
                    //Will be a dictionary.  Get the name of the dictionary, and the index element of interest:
                    string dictionary = prop.Substring(0, prop.IndexOf("["));
                    int index = Convert.ToInt32(prop.Substring(prop.IndexOf("[") + 1, prop.Length - prop.IndexOf("]")));
                    //Get the property info for the dictionary
                    PropertyInfo dictInfo = valueObject.GetType().GetProperty(dictionary);
                    if (dictInfo != null)
                    {
                        //Get the dictionary from the PropertyInformation
                        valueObject = dictInfo.GetValue(valueObject, null);
                        //Convert it to a list to provide easy access to the item of interest.  The List<> will be a set of key-value pairs.
                        List<object> values = ((IEnumerable)valueObject).Cast<object>().ToList();
                        //Use "GetValue" with the "value" parameter and the index to get the list object we want.
                        valueObject = values[index].GetType().GetProperty("Value").GetValue(values[index], null); 
                    }
                }
                else
                {
                    PropertyInfo propInfo = valueObject.GetType().GetProperty(prop);
                    if (propInfo != null)
                    {
                        valueObject = propInfo.GetValue(valueObject, null);
                    }
                }
            }
            return valueObject;
        }
