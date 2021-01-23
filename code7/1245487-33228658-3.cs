    public static List<string> getData()
       {
           List<string> data = new List<string>();
    
           using (SqlConnection con = new SqlConnection("Data Source=ACME-PC\\SQL;Integrated Security=true;Initial Catalog=ClinicApplication"))
           {
               SqlCommand cmd = new SqlCommand("select DISTINCT Patient_ID,First_Name,fromtime,totime,Date from tbl_AddPatientInfo", con);
               {
                   con.Open();
                   SqlDataReader dr = cmd.ExecuteReader();
    
                   while (dr.Read())
                   {
    					string id = "{" +
                           "\"id\":"  + "\""+dr["Patient_ID"].ToString()+"\"" + "," +
                           "\"title\":" + "\""+dr["First_Name"].ToString()"\"" + "," +
                           "\"start\":" + "\""+dr["Patient_ID"].ToString()"\"" + "," +
                           "\"end\":" + "\""+dr["Patient_ID"].ToString() + "\""+
                           "}";
    					data.Add(id);
                   }
                   return data;
               }
           }
       }
