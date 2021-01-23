    if (!Page.IsPostBack)
    {
            var datasource = new List<GridViewColumns>() {
            new GridViewColumns { 
                Col1 = "Col 1",
                Col2 = "Col 3",
                Col3 = "Col 3",
                Col4 = "Col 4",
                Col5 = "Col 5",
                Col6 = "Col 6"
            },
            new GridViewColumns { 
                Col1 = "Col 1",
                Col2 = "Col 3",
                Col3 = "Col 3",
                Col4 = "Col 4",
                Col5 = "Col 5",
                Col6 = "Col 6"
            }
          };
          
          GridView1.DataSource = datasource;
          GridView1.DataBind();
    }
