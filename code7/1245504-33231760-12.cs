    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Services;
    using System.Web.Script.Services;
    using System.Web.Script.Serialization;
    [WebService]
    [ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getData()
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            using (SqlConnection con = new SqlConnection("Data Source=ACME-PC\\SQL;Integrated Security=true;Initial Catalog=ClinicApplication"))
            {
                SqlCommand cmd = new SqlCommand("select DISTINCT Patient_ID,First_Name,fromtime,totime,Date from tbl_AddPatientInfo", con);
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Dictionary<string, object> item = new Dictionary<string, object>();
                        item.Add("id", dr["Patient_ID"]);
                        item.Add("title", dr["First_Name"]);
                        item.Add("start", dr["Patient_ID"]);
                        item.Add("end", dr["Patient_ID"]);
                        data.Add(item);
                    }
                }
            }
            return new JavaScriptSerializer().Serialize(data);
        }
    }
