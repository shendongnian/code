    using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\/Topology.accdb"))
    {
        con.Open();
        var trans = con.BeginTransaction();
        foreach (var pingReply in replies)
        {
            var status = "";
            if (pingReply.Reply.Status.ToString() == "Success")
            {
                online++;
                status = "Online";
            }
            else
            {
                status = "Offline";
                offline++;
            }
 
            string query = "UPDATE SystemStatus SET SystemStatus=@SystemStatus WHERE IP='" + ipAddr + "'";
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@SystemStatus", status);
            cmd.ExecuteNonQuery();         
        }
        trans.Commit();
    }
