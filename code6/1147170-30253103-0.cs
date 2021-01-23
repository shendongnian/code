           using System;
           using System.Collections.Generic;
           using System.Linq;
           using System.Web;
           using System.Web.UI;
           using System.Web.UI.WebControls;
           using System.Configuration;
           using System.Data.SqlClient;
           using System.Web.UI;
           using System.Web.UI.WebControls;
           using System.Collections;
          namespace AutoComplete
           {
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = ConfigurationManager
                            .ConnectionStrings["Default"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select LoginName from Users where " +
                        "LoginName like @SearchText + '%'";
                        cmd.Parameters.AddWithValue("@SearchText", prefixText);
                        cmd.Connection = conn;
                        conn.Open();
                        List<string> students = new List<string>();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                students.Add(sdr["LoginName"].ToString());
                            }
                        }
                        conn.Close();
                        return students;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
