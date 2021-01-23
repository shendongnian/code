    static void Main(string[] args)
    {
        OleDbConnectionStringBuilder bldr = new OleDbConnectionStringBuilder();
        bldr.DataSource = @"C:\Users\tekhe\Documents\Database2.mdb";
        bldr.Provider = "Microsoft.Jet.OLEDB.4.0";
        using (System.Data.OleDb.OleDbConnection cnxn = new OleDbConnection(bldr.ConnectionString))
        {
            cnxn.Open();
            Console.WriteLine("open");
            using (System.Data.OleDb.OleDbCommand cmd = new OleDbCommand())
            {
                cmd.Connection = cnxn;
                cmd.CommandType = System.Data.CommandType.Text;
                OleDbParameter dobParam = new OleDbParameter("@dob", OleDbType.Date);
                dobParam.Value = DateTime.Now;
                cmd.Parameters.Add(dobParam);
                cmd.CommandText = "INSERT INTO [Table1] ([Dob]) VALUES(@dob)";
                cmd.ExecuteNonQuery();
            }
        }
        Console.ReadKey();
    }
