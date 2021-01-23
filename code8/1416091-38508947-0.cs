    protected void btn_insert_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["DTset"];
            for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
            {
                string Id = ds.Tables[0].Rows[i][0].ToString();
                string Name = ds.Tables[0].Rows[i][1].ToString();
         
                SqlConnection con = new SqlConnection(connStr);
                SqlCommand cmd;
                if (!string.IsNullOrEmpty(Id) && !string.IsNullOrEmpty(Name)) {
                    cmd = new SqlCommand("insert into tbl1(ID,Name) values ('" + Id + "','" + Name + "')", con);
                    con.Open();
                    int j= cmd.ExecuteNonQuery();
                    con.Close();
                }
                string Id1 = ds.Tables[0].Rows[i][2].ToString();
                string Name1 = ds.Tables[0].Rows[i][3].ToString();
                string VehicleTypeId = ds.Tables[0].Rows[i][4].ToString();
                string VehicleType = ds.Tables[0].Rows[i][5].ToString();
                string Capacity = ds.Tables[0].Rows[i][6].ToString();
                
                if (!string.IsNullOrEmpty(Id1) && !string.IsNullOrEmpty(Name1) && !string.IsNullOrEmpty(VehicleTypeId) && !string.IsNullOrEmpty(VehicleType) && !string.IsNullOrEmpty(Capacity)) {
                    string InsQuery = "insert into tbl2(Id,Name,Subject,status,review) values ('" + Id1 + "','" + Name1 + "','" + Subject+ "','" + status+ "','" + review+ "')";
                    cmd = new SqlCommand(InsQuery,con);
                    con.Open();
                    int k=  cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        } 
