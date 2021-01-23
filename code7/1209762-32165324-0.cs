    public class Global : HttpApplication
    {
        void Session_Start(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection())
            {
                using (var cmd = new SqlCommand("select Hits from application", conn))
                {
                    //open the connection
                    conn.Open();
                    //send the query and store the results in a sqldatareader
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        Session["field1"] = rdr["Hits"];
                    }
                    else
                    {
                        // no record found, so start at 0
                        // maybe init the row in the table as well...
                        Session["field1"] = 0;
                    }
                }
            }
        }
