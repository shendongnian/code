    DataTable dt;
    
    private void GetRecords(int n) 
    {
        //...
        da.Fill(ds, "Employee");
        dt = ds.Tables["Employee"];
        AddDataBinding();
    }
    
    private void AddDataBinding()
    {
        txtLN.DataBindings.Add("Text", dt, "LastName");
        txtFN.DataBindings.Add("Text", dt, "FirstName");
        // ...
    }
