      protected void Page_Init(object sender, EventArgs e)
        {
            TextBox txt = new TextBox();
            txt.ID = "T1";
            txt.CssClass = "form-control";
            TextBoxesHere.Controls.Add(txt);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox txt = new TextBox();
            txt.ID = "T1";
            txt.CssClass = "form-control";
            TextBoxesHere.Controls.Add(txt);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)TextBoxesHere.FindControl("T1");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('" + txt.Text + "');", true);
           
        }
