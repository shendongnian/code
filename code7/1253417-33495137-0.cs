    SqlCommand cmd = new SqlCommand("SELECT o.OrderID AS ID,o.ProductID AS ProductID, p.ProductName AS 'ProductName', s.CompanyName AS Supplier, c.CategoryName AS Category, o.UnitPrice AS 'Unit Price', o.Quantity AS Quantity, (o.UnitPrice * o.Quantity) AS 'Sub-Total'" +
              "FROM [Order Details] o INNER JOIN Products p ON o.ProductID = p.ProductID " +
              "INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID INNER JOIN Categories c ON p.CategoryID = c.CategoryID WHERE OrderID = '" + DropDownList1.SelectedValue + "'", new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConnection1"].ConnectionString));
        cmd.Connection.Open();
        SqlDataReader sdrEmp = cmd.ExecuteReader();
        try
        {
            if (sdrEmp.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(sdrEmp);
                //Response.Write(dt);
                ViewState["CurrentTable"] = dt;
                dataGridView1.DataSource = dt;
                dataGridView1.DataBind();        // BIND DATABASE TABLE WITH THE GRIDVIEW.
            }
        }
