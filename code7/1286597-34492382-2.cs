    public partial class ChildClass : MainCLass
    {
        public override void Method1()
        {
            if(condition)
            {
                base.Method1();
                return;
            }
    
            //YOUR LOGIC
        }
    }
