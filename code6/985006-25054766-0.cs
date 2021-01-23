    private void LoadData()
    {
        DataSet ds = new DataSet();
        string sql = "SELECT OrderID, CustomerID, EmployeeID, OrderDate, Freight," + "ShipName, ShipCountry FROM Orders";
        string connectionString = "Data Source=localhost;Initial Catalog=Northwind;" + "Integrated Security=SSPI;";
        using(var conn = new SqlConnection(connectionString))
        using(var da = new SqlDataAdapter(sql, conn))
        {
            // if you use DataAdapter.Fill you don't need to open the connection 
            da.Fill(ds, "Orders");
            // ...    
        }
    }
