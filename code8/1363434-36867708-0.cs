    public class Test
    {
        public string MyValue {get;set;}
    }
    Dictionary<string, Test> DictOne = new Dictionary<string, Test>();
	Dictionary<string, string> DictTwo = new Dictionary<string, string>();
	
	DictOne.Add("DictOneKeyOne", new Test() { MyValue = "DictOneValueOne" } );
	DictTwo.Add("DictTwoKeyOne", "DictOneKeyOne");
	
	Test ValueFromDictOne = DictOne.ContainsKey(DictTwo["DictTwoKeyOne"]) ? DictOne[DictTwo["DictTwoKeyOne"]] : null;
