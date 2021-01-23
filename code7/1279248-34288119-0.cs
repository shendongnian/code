    public ActionResult ShowBasketADO()
        {
            List<Product> result = new List<Product>();
            List<int> plist = new List<int>((List<int>)Session["Basket"]);
            //We try to be sure that we only make a single query
            string query = "select id, descripcion from products where id in (" + string.Join(",", plist) + ")";
            //Start using IDisposable interface (yes, you can also use it for SqlCommand)
            using (SqlConnection myConnection = new SqlConnection(cnxString))
            {
                SqlCommand myCommand;
                SqlDataReader myReader;
                myConnection.Open();
                myCommand = new SqlCommand(query, myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Product item = new Product();
                    item.Id = (int)myReader[0];
                    item.Descripcion = (string)myReader[1];
                    result.Add(item);
                }
                myConnection.Close();
            }
            return View(result);
        }
