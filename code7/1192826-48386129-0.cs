    public class MyClass
    {
        [JsonProperty("MyEnumValue")]
        private string myEnumValue;
    
        public string Name { get; set; }
    
        [JsonIgnore]
        public MyEnum MyEnumValue 
        { 
            get
            {
                MyEnum outputValue = MyEnum.Default;
                Enum.TryParse(myEnumValue, out outputValue);
                return outputValue;
            }
        }
    }
