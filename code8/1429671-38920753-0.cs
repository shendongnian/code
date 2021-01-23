    public static System.Data.DataTable ReadExcelToTable(string path)
    {
        //Method codes
        ...
        // Return the data table
        return set.Tables[0];
    }    
    public void DrawCircuits(string name, double x, double y, double z,DataTable dt)
    {
         ...
         attRef.TextString = dt.Rows[0][0];
         ...
    }
    public DataTable ChangeDt(DataTable dt)
    {
        // Change dt codes
        ...
        // Return changed dt
        return dt;
    }
    public void Use(DataTable dt)
    {
        var myDt = ChangeDt(dt);
        for(i=0; i<=10; i++)
        {
           DrawCircuits("name", 1, 2, i, myDt);
        }
    }
