    public class TestClass : Dictionary<string, object>
    {
        public string StudentName
        {
            get { return this["StudentName"] as string; }
            set { this["StudentName"] = value; }
        }
    
        public string StudentCity
        {
            get { return this["StudentCity"] as string; }
            set { this["StudentCity"] = value; }
        }
    }
