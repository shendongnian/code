    public ActionResult UserDetails(DashBoard dash)
    { 
            
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                String sql = "SELECT DU.UserRMN, MU.Name, DeptName, MgrID, TLeadID FROM Details_Users DU, Master_Users MU where DU.UserRMN=MU.UserRMN";
                SqlCommand cmd = new SqlCommand(sql, cn);           
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<DashBoard> model = new List<DashBoard>();
                while(rdr.Read())
                {
                    var details = new DashBoard();
                    details.UserRMN = rdr["UserRMN"].ToString();
                    details.Name = rdr["Name"].ToString();
                    details.DeptID = rdr["DeptID"].ToString();
                    details.MgrID = rdr["MgrID"].ToString();
                    details.TLeadID = rdr["TLeadID"].ToString();
                    model.Add(details);
                }
                return View("ViewName", model);
            } 
            
