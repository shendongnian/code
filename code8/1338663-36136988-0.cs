    class BaseClass
    {
        public BaseClass(int? someVal = null) 
        { 
            if (someVal.HasValue) 
            {
                //Do something here
            }
        }
    }
    class DerivedClass : BaseClass
    {
        public DerivedClass(string somethingNew, int? someVal = null) 
            : base(someVal) // Pass someVal into BaseClass
        {
             // Do something with SomethingNew
        }
    }
