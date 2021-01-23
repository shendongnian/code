    public class Parent
    {
        private readonly Action _env1Method;
        private readonly Action _notEnv1Method;
        private readonly Model _model;
        private action _calc;
        public Parent(Model model, 
                      Action env1Method, 
                      Action notEnv1Method)
        {
            _model = model;
            _env1Method = env1Method;
            _notEnv1Method = notEnv1Method;
            Reset();
        }
        public void Reset()
        {
            _calc = _model.Env1 ? _env1Method : _notEnv1Method;
        }
    }
    public class Model
    {
        public bool Env1 { get; set; }
    }
    public class Child : Parent
    {
        public Child (Model model) : base (model, CalcHeavy, CalcLight) {}
    
        private void CalcHeavy()
        {
            Console.WriteLine("CalcHeavy is active");
        }
        
        private void CalcLight()
        {
            Console.WriteLine("CalcLight is active");
        }
    }
