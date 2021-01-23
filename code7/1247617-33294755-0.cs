    private  IList<int> GetIndices(ICollection<string> keyList, IList<IWebElement> objectList) {
        IList<int> result = new List<int>();
        foreach(string key in keyList) { 
            foreach(IWebElement element in objectList.Where(e => e.Name.Equals(key))) {
                result.Add(objectList.IndexOf(element));
            }
        }
        return result;
    }
    
