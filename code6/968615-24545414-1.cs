    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;
    using System.Collections.Specialized;
    namespace Curriculam_Mapping
    {
        /// <summary>
        /// Summary description for WebService1
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        [System.Web.Script.Services.ScriptService]
        // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        [System.Web.Script.Services.ScriptService]
        public class WebService1 : System.Web.Services.WebService
        {
             [System.Web.Script.Services.ScriptMethod()]
             [System.Web.Services.WebMethod]
             public static List<string> GetClass(string prefixText)
             {
                  SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ToString());
                  con.Open();
                  SqlCommand cmd = new SqlCommand("Select Class_Id,Title from Mst_Class where Title like @Name+'%'", con);
                  cmd.Parameters.AddWithValue("@Name", prefixText);
                  SqlDataAdapter da = new SqlDataAdapter(cmd);
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  List<string> ClassNames = new List<string>();
                  for (int i = 0; i < dt.Rows.Count; i++)
                  {
                      ClassNames.Add(dt.Rows[i][1].ToString());
                  }
                  return ClassNames;
               }
             }
         }
