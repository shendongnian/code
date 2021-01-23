    class SampleClass
    {
        // compiler-generated backing field initialized by the field initializer
        private readonly SampleEnum __sampleProp1 = SampleEnum.Value1;
    
        public SampleEnum SampleProp1 { get { return __sampleProp1; } }
        public SampleEnum SampleProp2 { get { return SampleEnum.Value1; } }
    }
