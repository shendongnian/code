     public class district : requestResponse
    {
        public int district_id { get; set; }
        public string district_name { get; set; }
    }
     [WebMethod]
        public List<district> getDropDown()
        {
            List<district> list = new List<district>();
            Pro_DbCon db = new Pro_DbCon();
            SqlConnection con = db.dbconnectionEMIS();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from DSS_District", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int idDistrict = Convert.ToInt32(dr[0]);
                    string DistrictTitle = dr[1].ToString();
                    district d = new district();
                    d.status = true;
                    d.msg = "";
                    d.district_id = idDistrict;
                    d.district_name = DistrictTitle;
                    list.Add(d);
                }
                if (list.Count < 1)
                {
                    district d = new district();
                    d.status = true;
                    d.district_id = 0;
                    d.district_name = "No Data Found";
                    d.msg = "";
                    list.Add(d);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                district s = new district();
                s.status = false;
                s.msg = ex.ToString();
                list.Add(s);
            }
            finally
            {
                con.Close();
            }
            return list;
        }
