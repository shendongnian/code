    public class Parameters
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
        public int MyProperty3 { get; set; }
    }
    
    public class AlgorithmParameters1
    {
        private Parameters parameters;
    
        public int MyProperty1 { get { return parameters.MyProperty1; } }
    
        public int MyProperty3 { get { return parameters.MyProperty3; } }
    
        public AlgorithmParameters1(Parameters parameters)
        {
            this.parameters = parameters;
        }
    }
    
    public class Algorithm1
    {
        public void Run(AlgorithmParameters1 parameters)
        {
            //Access only MyProperty1 and MyProperty3...
        }
    }
