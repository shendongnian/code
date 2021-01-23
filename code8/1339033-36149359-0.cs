    Dictionary<string,Tuple<string,string>> MyObjectCollection {get; set;}
    private void function()
    {
        MyObjectCollection = new Dictionary<string, Tuple<string,string>>();
        MyObjectCollection.Add("key1", Tuple.Create("test1", "test2"));               
    }
