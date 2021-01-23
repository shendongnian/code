     protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
               NameDropDownList.Items.Insert(0, new ListItem("Please Select a Product", "Please Select a Product"));
            }
            
       }
