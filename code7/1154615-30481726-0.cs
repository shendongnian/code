        class Program
    {
        static void Main(string[] args)
        {
            Model Model = new Model();
            Model.Env1 = true;
            Child Ch = new Child(Model);
            Ch.Calc(); Ch.Calc(); Ch.Calc();
            Console.WriteLine();
            Model.Env1 = false;
            Ch = new Child(Model);
            Ch.Calc(); Ch.Calc(); Ch.Calc();
            Console.ReadLine();
        }
    }
    public abstract class Parent
    {
        public Model Model { get; set; }
        public Parent(Model model)
        {
            Model = model;
            if (Model.Env1)
                Calc = CalcHeavy;
            else
                Calc = CalcLight;
        }
        public Action Calc;
        public abstract void CalcHeavy();
        public abstract void CalcLight();
    }
    public class Model
    {
        public bool Env1 { get; set; }
    }
    public class Child : Parent
    {
        public Child(Model model) : base(model) { }
        public override void CalcHeavy()
        {
            Console.WriteLine("CalcHeavy is active");
        }
        public override void CalcLight()
        {
            Console.WriteLine("CalcLight is active");
        }
    }
