    class Program
    {
        static void Main(string[] args)
        {
            System.Data.OleDb.OleDbConnectionStringBuilder bldr = new System.Data.OleDb.OleDbConnectionStringBuilder();
            bldr.DataSource = @"C:\Users\tekhe\Documents\Database2.mdb";
            bldr.Provider = "Microsoft.Jet.OLEDB.4.0";
    
            using (System.Data.OleDb.OleDbConnection cnxn = new System.Data.OleDb.OleDbConnection(bldr.ConnectionString))
            {
                cnxn.Open();
                Console.WriteLine("open");
    
                using (System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand())
                {
                    cmd.Connection = cnxn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO [Table1] ([Dob]) VALUES(#" + DateTime.Now.ToString() + "#)";
                    cmd.ExecuteNonQuery();
                }
            }
            Console.ReadKey();
        }
    }
