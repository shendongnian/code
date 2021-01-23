    public class BaseClass
    {
        public override OnLoad(object sender, EventArgs e)
        {
            base.OnLoad(e);
    
            SetLabels();        //This will call the appropriate child class method
        }
    
        public virtual void SetLabels()
        {
    
        }
    }
    
    public class ChildClass1 : BaseClass
    {
        public override void SetLabels()
        {
            //Set the label here
        }
    }
    
    public class ChildClass2 : BaseClass
    {
        public override void SetLabels()
        {
            //Set the label here
        }
    }
