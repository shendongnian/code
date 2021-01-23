    class BaseClass 
    {
        public int version { get; set; }
    }
    class FirstVersion: BaseClass 
    {
        public string condition { get; set; }
    }
    class SecondVersion: BaseClass
    {
        public IEnumerable<string> condition { get; set; }
    }
    public void Deserialize (string jsonString)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        BaseClass myData = serializer.Deserialize<BaseClass>(jsonString);
        switch (myData.version) 
        {
            case 1:
                FirstVersion firstVersion = serializer.Deserialize<FirstVersion>(jsonString);
                // ...
                break;
            case 2:
                SecondVersion secondVersion = serializer.Deserialize<SecondVersion>(jsonString);
                // ...
                break;
        }
