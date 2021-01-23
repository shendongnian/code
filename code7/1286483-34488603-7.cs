    // GridView1_NeedDataSource
    protected void GridView1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        BindGridViewData();
    }
   
    //Bind Grid View 
    private void BindGridViewData()
    {
     var table = new DataTable();
             table .Columns.Add("Source");
             table .Columns.Add("Destination");
             table .Columns.Add("Date");
        
           if()
           {
             
             foreach (var item in data)
             {
                table.Rows.Add(Source,Destination,Date);
             }
             //Binding to Gridview
             GridView1.DataSource = dt;
             
          }
          else
          {
              
              GridView1.DataSource = dt; 
           
          }
    }
