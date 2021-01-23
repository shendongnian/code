    [System.Web.Services.WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string getData(){
       List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
       Dictionary<string, string> item;
       using (SqlConnection con = new SqlConnection("Data Source=ACME-PC\\SQL;Integrated Security=true;Initial Catalog=ClinicApplication"))
       {
    	   SqlCommand cmd = new SqlCommand("select DISTINCT Patient_ID,First_Name,fromtime,totime,Date from tbl_AddPatientInfo", con);
    	   {
    		   con.Open();
    		   SqlDataReader dr = cmd.ExecuteReader();
    
    		   while (dr.Read())
    		   {
    				item = new Dictionary<string, string>();
    				item.Add("id", dr["Patient_ID"]+"");
    				item.Add("title", dr["First_Name"]+"");
    				item.Add("start", dr["Patient_ID"]+"");
    				item.Add("end", dr["Patient_ID"]+"");
    				data.Add(item);
    		   }
    		   return new JavaScriptSerializer().Serialize(data);
    	   }
        }
    }
