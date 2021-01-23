    class Program
        {
            static void Main(string[] args)
            {
                testClass tc = new testClass();
                DataTable dt = tc.getTestData();
    
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Console.WriteLine("Account No {0} Occurence {1}", dt.Rows[i]["ACCNO"].ToString(), dt.Rows[i]["Occurence"].ToString());
                }
            }
        }
    
        class testClass
        {
            public string AccountNo { get; set; }
    
            private SqlConnection Conn;
    
            private void TestConnect()
            {
                string strConn = "Data source = .\\SQLEXPRESS2012; Initial catalog = TEST; Integrated security = SSPI;";
                Conn = new SqlConnection(strConn);
            }
    
            public DataTable getTestData()
            {
                TestConnect();
                string cmdStr = "SELECT ACCNO, COUNT(XYZ.ACCNO) AS 'Occurence' FROM XYZ GROUP BY ACCNO;";
                SqlCommand cmd = new SqlCommand(cmdStr, Conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                try
                {
                    Conn.Open();
                    sda.Fill(dt);
                }
                catch (SqlException se)
                {
                    Console.WriteLine("Error occured {0}", se.ToString());
                }
                finally
                {
                    Conn.Close();
                }
    
                return dt;
            }
        }
