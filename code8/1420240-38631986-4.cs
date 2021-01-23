    public class SomeClass
    {
        public string Str { get; private set; }
    
        protected void Page_Load(object sender, EventArgs e)
        {
          if (!Page.IsPostBack)
          {
            Str = "i am a string";
            showString();
          }
        }
        
        void showString()
        {
          aspLabel.Text = Str;
        }
    }
    public class SomeOtherClass
    {
        public SomeOtherClass()
        {
            SomeClass someClass = new SomeClass();
            var otherStr = someClass.Str;
        }
    }
