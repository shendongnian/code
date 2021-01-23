    class Program
    {
        static void Main(string[] args)
        {
            var x = new MyClass();
            Debug.Print("{0}", x.SampleProp1);
            Debug.Print("{0}", x.SampleProp2);
        }
        public class MyClass
        {
            public enum SampleEnum { Value0, Value1 , Value2 };
            public SampleEnum SampleProp1 { get; } = SampleEnum.Value1;
            public SampleEnum SampleProp2 { get { return SampleEnum.Value1; } }
        }
    }
