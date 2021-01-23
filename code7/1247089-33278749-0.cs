    public partial class WebForm1 : System.Web.UI.Page
    {
      int n = 0;
      protected void Page_Load(object sender, EventArgs e)
        {
            n = int.Parse(NumHidden.Value);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            n++;
            Label1.Text = NumHidden.Value = n.ToString();
        }
    
        protected void Button2_Click(object sender, EventArgs e)
        {
            n--;
            Label1.Text = NumHidden.Value = n.ToString();
        }
