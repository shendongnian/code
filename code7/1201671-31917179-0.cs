            protected void Page_Load(object sender, EventArgs e)
            {
                LoadModalForm(testul);
            }
    
            protected void LoadModalForm(Control ulCtrl)
            {
    
                var li = new HtmlGenericControl("li");
    
                // creating link with href
                var lnk = new HyperLink { NavigateUrl = "#modal-editprofile" };
    
                lnk.Attributes.Add("data-toggle", "modal");
                lnk.Text = "Edit";
                li.Controls.Add(lnk);
    
    
                ulCtrl.Controls.Add(li);
            }
