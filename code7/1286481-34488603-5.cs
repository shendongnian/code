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
             //All my logics where i am generating value for this "Source,Destination,Date" Column.
             foreach (var item in data)
             {
                table.Rows.Add(Source,Destination,Date);
             }
             //Binding to Gridview
             GridView1.DataSource = dt;
             GridView1.DataBind();
          }
          else
          {
              //No Records so display gridview with "No records" along with columns.
              GridView1.DataSource = dt; //Here i will not be having any data for this 3 columns Source,Destination,Date
              GridView1.DataBind();//But My gridview is not visible
          }
    }
