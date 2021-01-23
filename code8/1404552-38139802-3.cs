       for (int i = 3; i <= 41; i++)
          {
              try
                {
        
      datatable1.Rows.Add(s, pageIndex.ToString(), tmpNames, tmpLocations, tmtimes, tmprices);
      datatable1.AcceptChanges();   
      dataGridView2.DataSource = datatable1;               
      this.dataGridView2.Update();
                                   
        
              }
          }
