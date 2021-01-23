    public class MyProcess()
    {
        private ISteppable Step0 = new ...
        private ISteppable Step1 = new ...
        private ISteppable Step2 = new ...
        private ISteppable Step3 = new ...
        private IEnumerable<Step> steps = 
        {
            new Step(step0),
            new Step(step1),
            new Step(step0), // yes, my process needs step0 again!
            new Step(step2),
         }
   
         public IEnumerable<Step> Steps {get{return this.steps;}
     }
     static void Main()
     {
         MyProcess process = new MyProcess();
         // 3 steps full speed:
         foreach (var step in process.Steps.Take(3))
         {
             process.Step();
         }
         // slow speed until step == ...
         foreach (var step in process.Steps.Skip(3).While(step => step != ...)
         {
             process.Step(TimeSpan.FromSeconds(3);
         }
     }
