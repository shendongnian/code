    class ValueHolder {
    public string id { get; set; }
    public string otherProp { get; set; }
    }
    var dic1 = new Dictionary<string, ValueHolder>();
    dic1.Add("b@b.com", new ValueHolder { id = "1", otherProp = "Lorem" });
    dic1.Add("a@a.com", new ValueHolder { id = "1", otherProp = "Lorem" });
    var dic2 = new Dictionary<string, ValueHolder>();
    dic2.Add("b@b.com", new ValueHolder { id = "2", otherProp = "Lorem" });
    dic2.Add("a@a.com", new ValueHolder { id = "2", otherProp = "Lorem" });
    var listOfDic = new List<Dictionary<string, ValueHolder>> { dic1, dic2 };
    var result = JsonConvert.SerializeObject(listOfDic, Formatting.Indented);
