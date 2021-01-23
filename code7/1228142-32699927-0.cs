    public partial class _Default : Page
        {
            protected void Page_PreInit(object sender, EventArgs e)
            {
                MasterPage master = this.Master; 
                // Access any control of Content Page now ....
                label1.Text = "Inside PreInit";
                
            }
        }
