        protected void Page_Load(object sender, EventArgs e)
            {
    if(!isPostBack){
                TextBox txtBox = new TextBox();
                txtBox.ID = "newButton";
                form1.Controls.Add(txtBox);
                txtBox.Text = "initialVal";
        }
                if (IsPostBack && Session["change"] == null)
                {
                    txtBox.Text = "change";
                    Session["change"] = true;
                }
            }
