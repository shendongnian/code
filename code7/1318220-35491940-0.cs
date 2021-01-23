    public DataTable ConvertToDatatable(List<ChildBasic> list)
    {
        DataTable dt = new DataTable();
    
        dt.Columns.Add("child_id");
        dt.Columns.Add("child_firstname");
        dt.Columns.Add("parent_surname");
        dt.Columns.Add("club_name");
        foreach (var item in list)
        {
            var row = dt.NewRow();
    
            row["child_id"] = item.child_id;
            row["child_firstname"] = Convert.ToString(item.child_firstname);
            row["parent_surname"] = Convert.ToString(item.parent_surname);
         	row["club_name"] = Convert.ToString(item.parent_surname);
    
            dt.Rows.Add(row);
        }
    
        return dt;
    }
    private void GridViewDataBind()
        {
            GridView1.DataSource = ConvertToDatatable(DetailsAccessLayer.GetAllChildBasicDetails());
            GridView1.DataBind();        
        }
