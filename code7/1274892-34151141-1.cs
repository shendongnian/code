    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class AutoCompleteCity : System.Web.UI.Page
    {
        [WebMethod]
        public static void SaveData(string status, string chkBoxValue, string DueDate)
        {
            List<string> Emp = new List<string>();
            string query = string.Format("Insert Into [Table] Values ({0},{1},{2})", status, chkBoxValue, DueDate);
            using (SqlConnection con = new SqlConnection("your Connection string"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    }
