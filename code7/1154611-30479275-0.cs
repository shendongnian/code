    public class Parent
    {
        private readonly StateHandler _env1Method;
        private readonly StateHandler _notEnv1Method;
        public Model Model { get; set; }
        public Parent(Model model, 
                      StateHandler env1Method, 
                      StateHandler notEnv1Method)
        {
            Model = model;
            _env1Method = env1Method;
            _notEnv1Method = notEnv1Method;
        }
        public delegate void StateHandler();
        public StateHandler Calc;
        public void Reset()
        {
            Calc = Model.Env1 ? _env1Method : _notEnv1Method;
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
