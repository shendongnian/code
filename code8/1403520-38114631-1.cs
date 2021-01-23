        public virtual JsonResult GetDropDown()
        {
            string query = "SELECT StoreID";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            List<ListItem> customers = new List<ListItem>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new ListItem
                            {
                                Value = sdr["CustomerId"].ToString(),
                                Text = sdr["Name"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return Json(customers, JsonRequestBehavior.AllowGet);
        }
