        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
           try
            {
                using (SqlConnection con = new SqlConnection("Data Source = [SERVERNAME]; Initial Catalog = CustomerOrders; Integrated Security = true"))
                {
                    String name = dropDownList.SelectedItem.Text;
                    SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM Customer INNER JOIN Orders ON Customer.CustomerID = Orders.ReferenceID WHERE Name = '" + name + "'", con);
                    con.Open();
                    DataTable dtbl = new DataTable();
                    cmd.Fill(dtbl);
                    gvPhoneBook.DataSource = dtbl;
                    gvPhoneBook.DataBind();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
