     public void BindResultsTable()
        {
               datatable1=null;
                datatable1.Columns.Add("catagory", typeof(System.String));
                datatable1.Columns.Add("PageNo", typeof(System.String));
                datatable1.Columns.Add("Name", typeof(System.String));
                datatable1.Columns.Add("price", typeof(System.String));
                datatable1.Columns.Add("Time", typeof(System.String));
                datatable1.Columns.Add("Location", typeof(System.String));
      
    
              for (int i = 3; i <= 41; i++)
              {
                  try
                    {
        
          datatable1.Rows.Add(s, pageIndex.ToString(), tmpNames, tmpLocations, tmtimes, tmprices);
          datatable1.AcceptChanges();   
        
        
                  }
              }
          dataGridView2.DataSource = null;
          dataGridView2.DataSource = datatable1;               
          this.dataGridView2.Update();
        }
         
