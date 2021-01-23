     protected void Page_Load(object sender, EventArgs e)
            {
                if (Page.IsPostBack == true)
                {
                    Response.Write("Page is posted back");
                }
            }
    
            protected void cboptions_CheckedChanged(object sender, EventArgs e)
            {
                btn.Enabled = cboptions.Checked;
            }
            protected void Button_Click(object sender, EventArgs e)
            {
                int a = Convert.ToInt32(txtFirst.Text);
                int b = Convert.ToInt32(txtSecond.Text) + a;
                result.Text = b.ToString();
            }
