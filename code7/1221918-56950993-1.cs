    public class MngEvent
    {
    public DataTable ShowEvent()
        {
            try
            {
              SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ospDB"].ConnectionString);
                SqlCommand cmd = new SqlCommand("usp_SelectAllConfrence", con);
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                if (con.State.Equals(ConnectionState.Closed))
                    con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      }
