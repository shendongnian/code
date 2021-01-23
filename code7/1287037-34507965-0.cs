     private void BindProducts()
     {
     SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["kernelCS"].ConnectionString);
     con.Open();
     SqlDataAdapter   Gridad = new SqlDataAdapter("select * from tbl_price", con);
     DataTable  Gridds = new DataTable();                 
     Gridds.Clear();
     Gridad.Fill(Gridds);
     gridviewProducts.DataSource = Gridds;
     con.Close();
     }
