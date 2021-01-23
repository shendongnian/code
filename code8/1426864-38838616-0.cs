    public static List<string> CreateRowData(string input) {
        var returnList = new List<string> { "type" };
        var inputs = input.Split(',').Select(s => s.Trim());
        foreach (var item in inputs) {
            returnList.Add(item);
        }
        returnList.Add("shares");
        return returnList;
    }
