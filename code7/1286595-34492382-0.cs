    public partial class ChildClass : MainCLass
    {
        public override void Method1()
        {
            if(condition)
            {
                return base.Method1();
            }
    
            //YOUR LOGIC
        }
    }
