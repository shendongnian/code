    public interface IMasterData
    {
        string Prop1 { get; set; }
        string Prop2 { get; set; }
    }
    public interface IBasicData : IMasterData
    {
        string Prop3 { get; set; }
        string Prop4 { get; set; }
    }
    public class WithData : IBasicData
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public string Prop3 { get; set; }
        public string Prop4 { get; set; }
    }
    public class SomeType
    {
        public string value1, value2, value3, value4;
    }
    public interface IGetValues
    {
        IMasterData FillValues(SomeType element);
    }
    public class MyClass : IGetValues
    {
        public IMasterData FillValues(SomeType element)
        {
            var u=new WithData()
            {
                Prop1=element.value1,
                Prop2=element.value2,
                Prop3=element.value3,
                Prop4=element.value4
            };
            return u;
        }
    }
