    public static class MyFrameworkClass
    {
        // framework override
        public static void whatever(Master master) 
        {
            master.FunctionInMaster();
            master.VariableInMaster = true;
        }
    }
    public class MyClass : Master
    {        
        protected override void Initialize() 
        {
            MyFrameWorkClass.whatever(this);
            FunctionInMaster();
            VariableInMaster = true;
        }
    }
