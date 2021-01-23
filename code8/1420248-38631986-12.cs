    public class SomeClass
    {
        private string str;
    
        protected void Page_Load(object sender, EventArgs e)
        {
          if (!Page.IsPostBack)
          {
            str = "i am a string";
            showString();
          }
        }
        protected void Btn_Click(object sender, EventArgs e)
        {
           exportToExcel(str);
        }
        
        void showString()
        {
          aspLabel.Text = str;
        }
    }
