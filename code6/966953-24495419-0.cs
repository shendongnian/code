    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label txt = Label1;
            int i = Convert.ToInt32(txt.Text);
            if (i == 4)
            {
                Timer1.Enabled = false;
            }
            else
            {
                i++;
                Label1.Text = i.ToString();
            }
        }
    }
