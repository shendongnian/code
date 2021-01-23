    public struct MySerializable : ISerializable<string>
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        
        // ****See Here: Ctor taking serialized type to restore field vals
        public MySerializable(string serializedData) : this()
        {
            var stringVals = serializedData.Split(',');
            Value1 = Convert.ToInt32(stringVals[0]);
            Value2 = Convert.ToInt32(stringVals[1]);
        }
        
        public override string ToString()
        {
            return string.Format("{0},{1}", Value1, Value2);
        }
        
        // ****See  Here: serializing field vals to string
        public string Serialize()
        {
            return ToString();
        }
    }
