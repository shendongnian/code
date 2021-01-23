    public class JsonTestObject
    {
        
    }
    public class JsonTestResultValue : JsonTestObject
    {
        public int b;
        public int c;
    }
    public class JsonTestResultArray : JsonTestObject
    {
        public JArray Array { get; set; }
        public JsonTestResultArray(JArray array)
        {
            Array = array;
        }
    }
