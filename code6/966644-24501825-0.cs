           static  public SqlCeConnection OpenSQL()
        {
            SqlCeConnection cncount = new SqlCeConnection(@"Data Source = " + Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\Database.sdf; Password =''");
            return cncount;
        }
        static  public DataTable  DoSelect( string strSQL)
        {
            SqlCeConnection cn = OpenSQL();
 
            DataTable dtRetValue = new DataTable();
            using (SqlCeDataAdapter da = new SqlCeDataAdapter())
            {
                using (SqlCeCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = strSQL;
                    da.SelectCommand = cmd;
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    try
                    {
                        //using (SqlCeDataReader reader = da.SelectCommand.ExecuteReader())
                        SqlCeDataReader metsDr = da.SelectCommand.ExecuteReader();
                        dtRetValue.Load(metsDr);
                        return dtRetValue;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error - DoSelect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return null;
                    }
                }
            }
        }
