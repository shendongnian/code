    public abstract class stuff1 : Page
    {
        public abstract void print();
    }
    
    
    public partial class _Default : stuff1
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        public override void print()
        {
            throw new NotImplementedException();
        }
    }
