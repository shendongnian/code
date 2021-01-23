         public JsonResult GetEmpId(string value)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string connstr1 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(connstr1);
            con.Open();
            List<SelectListItem> list = new List<SelectListItem>();
            if (value == "AGENT")
            {
                // query the tb_AgentDetails table and get values.
                SqlCommand cmd1 = new SqlCommand("select AgentId from tb_AgentDetails", con);
                using (SqlDataReader rdr = cmd1.ExecuteReader())
                {
                    List<string> result = new List<string>();
                    while (rdr.Read())
                    {
                        string EmpId = rdr["AgentId"].ToString();
                        result.Add(EmpId);
                    }
                    rdr.Close();
                   
                    for (int i = 0; i < result.Count; i++)
                    {
                        list.Add(new SelectListItem { Text = result[i].ToString(), Value = result[i].ToString() });
                    }
                    con.Close();
                }
            }
            if (value == "REPRESENTATIVE")
            {
                //query the tb_RepDetails table and get values.
                SqlCommand cmd1 = new SqlCommand("select RepId from tb_RepDetails", con);
                using (SqlDataReader rdr = cmd1.ExecuteReader())
                {
                       List<string> result = new List<string>();
                       while (rdr.Read())
                        {
                            string EmpId = rdr["RepId"].ToString();
                            result.Add(EmpId);
                        }
                       rdr.Close();
                       
                       for (int i = 0; i < result.Count; i++)
                       {
                           list.Add(new SelectListItem { Text = result[i].ToString(), Value = result[i].ToString() });
                       }
                       con.Close();
                 }
            }
          return Json(list, JsonRequestBehavior.AllowGet);
        }
