    Student Details = new Student();
    
    DataSet ds = Details.Marks();
    
    DataTable dt = ds.Tables[0];
    
    if (dt.Rows.Count > 0)
    {
        var result = from d in dt.AsEnumerable()
                     where d["RollNo"].ToString() == txtRgNo.Text && 
                           d["Name"].ToString() == txtName.Text
                     select new
                     {
                         RollNo = d.Field<int>("RollNo"),
                         Name = d.Field<string>("Name")
                     };
        
        if (result.Any())
        {
            // results is not empty ...
        }
    }
