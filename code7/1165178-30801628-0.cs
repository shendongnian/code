     protected void Page_Load(object sender, EventArgs e) 
     {
        if(!Page.IsPostBack)
        { 
           DisplayDatainGrid(); //All data in GridView 
           AddDataDropList(); //Load data in Dropdownlist 
        }
     }
