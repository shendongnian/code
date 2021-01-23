    public int CheckExisting(String sqlDbQry, String sTable)
    {
        try
        {
            Qry = sqlDbQry;
            con = new OleDbConnection(connectionstr);
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            cmd = new OleDbCommand(Qry, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
                rQry = Convert.ToInt32(dr[0].ToString());
            con.Close();
            return rQry;
        }
        catch (OleDbException ex)
        {
            string message = ex;
            //put your message on a texbox or alert handler error on the web
            //or while debugging use a breakpoint on the exception handler
            //use log
            Console.WriteLine(message);
        }
    }
