    using System.Web.Services;
    [WebMethod]
    public static List<object> GetChartData()
    {
        string query = "select Share,Value  from Table";
        string constr = ConfigurationManager.ConnectionStrings["dbcn"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "Share", "Value"
    });
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        chartData.Add(new object[]
                    {
                        sdr["Share"], sdr["Value"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }
