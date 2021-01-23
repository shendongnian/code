    public class blCustomerInformation
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter ada;
        blConnection myConn = new blConnection();
        public blCustomerInformation()
        {
            conn = new SqlConnection(myConn.getConstr());
            conn.Open();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            ada = new SqlDataAdapter();
            ada.SelectCommand = cmd;
        }
}
