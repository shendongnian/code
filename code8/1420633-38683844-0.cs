    public class TestClass
        {
            public int id { get; set; }
            public string fname { get; set; }
            public string lname { get; set; }
            public string job { get; set; }
            public string role { get; set; }
            public string address { get; set; }
            public override bool Equals(object obj)
            {
                if (obj.GetType().Name != this.GetType().Name)
                {
                    return false;
                }
                TestClass testclassObject = (TestClass)obj;
                if (testclassObject.id != this.id)
                {
                    return false;
                }
    
                return true;
            }
