    protected void LoadProductsFromDatabase()
        {
            System.Collections.Generic.List<Inventory> My_DDL_Datasource = new System.Collections.Generic.List<Inventory>();
            // write your code to pull database values
            // populating list with sample data for stackoverflow
            // make sure to use a replace statement to remove any delimiter characters that may be in the description
            My_DDL_Datasource.Add(new Inventory(1, "Product 1".Replace("|", ""), 0.50m));
            My_DDL_Datasource.Add(new Inventory(2, "Product 2".Replace("|", ""), 1.50m));
            My_DDL_Datasource.Add(new Inventory(3, "Product 3".Replace("|", ""), 0.50m));
            My_DDL_Datasource.Add(new Inventory(4, "Product 4".Replace("|", ""), 10.50m));
            ddlProducts.DataSource = My_DDL_Datasource;
            ddlProducts.DataBind();
        }
