    static void Main(string[] args)
        {
         
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\dev\Sandbox\Sandbox.Console\test.db;Version=3;"))
            {
                conn.Open();
                conn.Trace += conn_Trace;
                
                using(SQLiteCommand cmd = new SQLiteCommand("Select * from tbl1", conn))
                {
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
    
                    }
                }
    
                conn.Trace -= conn_Trace;
                conn.Close();
            }
        }
    
        static void conn_Trace(object sender, TraceEventArgs e)
        {
            System.Console.WriteLine(e.Statement);
        }
