        public JsonResult TotalNumberofSubCateg(string subcateg)
        {
            int rowcount;
            string constr = ConfigurationManager.ConnectionStrings["StockConnString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM DisplayCenterTab Where SubCategory = @S0 ", con);
            cmd.Parameters.AddWithValue("@S0", subcateg );
            cmd.CommandType = CommandType.Text;
            rowcount = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Json(rowcount, JsonRequestBehavior.AllowGet);
        }
