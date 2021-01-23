    public class SomeDBClass
    {
        static DataTable exec_DT(DBConnection conn, DBCommand cmd)
        {
            DataTable retVal = new DataTable();
            conn.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                retVal.Load(rdr);
                rdr.Close();
            }
            return retVal;
        }
    }
