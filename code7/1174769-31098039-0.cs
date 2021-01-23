    struct TwoLists
    {
        public List<Person> plist;
        public List<Car> carlist;
    }
...
    TwoLists lists;
    lists.plist = new List<Person>();
    lists.carlist = new List<Car>();
    ...
    string json = "";
    System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    json = oSerializer.Serialize(lists);
    
    return json;
