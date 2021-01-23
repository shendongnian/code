    public List<string> FetchValue(string outerKey, string innerKey)
        {
            List<string> result = null;
            if(myDictionary.ContainsKey(outerKey))
                result = myDictionary[outerKey][innerKey];
            return result;
        }
