    protected void Page_Load(object sender, EventArgs e)
            {
                System.Web.UI.WebControls.LinkButton add_more = new System.Web.UI.WebControls.LinkButton();
                add_more.Text = "<i class='glyphicon glyphicon-plus'></i> Add more";
                add_more.Click += new System.EventHandler(Button1_Click);
                add_more.Attributes.Add("style", "margin-left:435px");
                add_more.Attributes.Add("Class", "btn btn-default btn-xs");
    
    
                placeHolder.Controls.Add(add_more);
                
            }
 
