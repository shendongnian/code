    public class TestClass
    {
        [MyValidationAspect("OtherProperty")]
        public int TestProperty { get; set; }
        public int OtherProperty { get; set; }
    }
