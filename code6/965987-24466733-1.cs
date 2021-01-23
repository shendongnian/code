     MySqlConnection con = new MySqlConnection("Server=localhost;Database=blah;Uid=root;Pwd=blah");
                    string query = "select OrderID  from oders ";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    usergrid.DataSource = ds;
                    usergrid.DataBind();
