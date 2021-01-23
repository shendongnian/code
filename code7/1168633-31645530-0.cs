    public static DataTable GridData(string para1, string para2)
        {
            
            using (SqlConnection con = new SqlConnection(strconn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.CommandText = "SP_Name";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@para1", para1);
                    cmd.Parameters.AddWithValue("@para2", para2);
                    cmd.Connection=con;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    return dt;
                }
            }
        }
     [WebMethod]
        public static List<ClassName> BindGridData(string para1,string para2)
        {
            DataTable dt = ClassName.GridData(para1, para2);
            List<ClassName> list = new List<ClassName>();
            foreach (DataRow dr in dt.Rows)
            {
                ClassName pa = new ClassName();
                pa.para1 = Convert.ToString(dr["para1"]);
                pa.para2 = Convert.ToString(dr["para2"]);
                list.Add(pa);
            }
            return list;
        }
