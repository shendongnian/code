    //common function for databound
    Public void databind()
    {
         DataList1.DataSource = // ypur datasource
         DataList1.DataBind();
    } 
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            databind();
        }
    }
    
    //Do the necessary coding in DataList1_SelectedIndexChanged
    
    Protected void DataList1_SelectedIndexChanged(Object sender, EventArgs e)   
    {
        DropDownList ddl = (DropDownList)sender;
        //get whatever value you need
    
        databind();//Call To Function that binds To datalist
    }
