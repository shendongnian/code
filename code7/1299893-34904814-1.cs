    public class MyFrameworkClass : Master
    {
        // framework override
        protected void whatever() 
        {
            FunctionInMaster();
            VariableInMaster = true;
        }
    }
    public class MyClass : MyFrameworkClass 
    {        
        protected override void Initialize() 
        {
            whatever();
    
            FunctionInMaster();
            VariableInMaster = true;
        }
    }
