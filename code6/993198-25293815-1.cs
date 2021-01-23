    public enum MyEnum { None = 0, Value1 = 1, Value2 = 2, Value3 = 4 };
    public class SomeClass
    {
        public MyEnum MyProp { get; set; }
        public string Test = "aaaa";
        public bool ShouldSerializeMyProp()
        {
            return MyProp != MyEnum.None;
        }
    }
---
    var retVal1 = JsonConvert.SerializeObject(new SomeClass() { MyProp= MyEnum.None });
    var retVal2 = JsonConvert.SerializeObject(new SomeClass() { MyProp = MyEnum.Value1 });
