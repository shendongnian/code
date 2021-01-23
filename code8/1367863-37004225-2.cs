    public class ClassA : IMyInterface {
        public IEnumerable<LookUpViewModel> LookUp { get; set; }
        public int MyPropertyA { get; set; }
        //other properties
    }
    public class ClassB : IMyInterface {
        public IEnumerable<LookUpViewModel> LookUp { get; set; }
        public string MyPropertyB { get; set; }
        //other properties
    }
