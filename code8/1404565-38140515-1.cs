    public class A
    {
        public virtual string Text { get; set; }
    }
    
    public class B : A
    {
        public override string Text 
        {
             get { return base.Text; }
             set { base.Text = value; }
        }
    }
