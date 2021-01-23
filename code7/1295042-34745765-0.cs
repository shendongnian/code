    public partial class Form1 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (int.TryParse(textBox1.Text, out id))
            {
                OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder();
                Builder.Provider = "Microsoft.Jet.OLEDB.4.0";
                Builder.DataSource = Path.Combine(Application.StartupPath, "Database1.mdb");
    
                using (OleDbConnection cn = new OleDbConnection(Builder.ConnectionString))
                {
                    string selectStatement = "SELECT UserName, JoinMonth FROM Users WHERE Identifier = @Identifier";
                    using (OleDbCommand cmd = new OleDbCommand { CommandText = selectStatement, Connection = cn })
                    {
                        cmd.Parameters.Add(new OleDbParameter { ParameterName = "@Identifier", DbType = DbType.Int32, Value = id });
                        cn.Open();
                        OleDbDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            Console.WriteLine("{0} - {1}", dr.GetString(0), dr.GetString(1));
                        }
                        else
                        {
                            Console.WriteLine("Not located");
                        }
                    }
                }
            }
        }
    }
    
     
