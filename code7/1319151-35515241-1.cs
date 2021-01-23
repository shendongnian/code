    public partial class WebForm1 : System.Web.UI.Page
    {
        protected TextBox txt;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Request.Form.AllKeys.Any(x => x == "TextBox1"))
                CreateTextBox();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (txt != null)
                lbl.Text = "TextBox value is " + txt.Text;
            else
                lbl.Text = "No value in TextBox";
        }
        protected void btnCreateTextBox_Click(object sender, EventArgs e)
        {
            if (txt == null)
            {
                CreateTextBox();
            }
        }
        private void CreateTextBox()
        {
            txt = new TextBox();
            txt.ID = "TextBox1";
            placeHolder.Controls.Add(txt);
        }
    }
