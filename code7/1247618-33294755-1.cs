    private IList<int> GetIndicesNotForEach(ICollection<string> keyList, IList<IWebElement> objectList) {
        List<int> result = new List<int>();
        var sel = objectList.Where(e => keyList.Contains(e.Name)).Select(e => objectList.IndexOf(e));
        result.AddRange(sel);
        return result;
    }
