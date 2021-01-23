    public partial class _Default : System.Web.UI.Page
    {
        static int count = 120;
        protected void Page_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label1.Visible = true;
            label1.Text = TimeSpan.FromSeconds(count).ToString(@"mm\:ss");
        }
        protected void tmer1_Tick(object sender, EventArgs e)
        {
            var c = --count;
            label1.Text = TimeSpan.FromSeconds(c).ToString(@"mm\:ss");
            int m = 0;
 
            if (c <= m)
            {
                count = 120;
                timer1.Enabled = false;
                Response.Redirect("http://www.google.com");
            }
        }
    }
