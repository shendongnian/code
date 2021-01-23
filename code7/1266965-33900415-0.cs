    static void Main(string[] args)
    {
        string ip, port = null;
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].StartsWith("/i:"))
                ip = args[i].Substring(args[i].IndexOf(':') + 1);
            else if (args[i].StartsWith("/p:"))
                port = args[i].Substring(args[i].IndexOf(':') + 1);
        }
        // Default the port value to 2638 (since I have no idea if that changes).
        if (string.IsNullOrEmpty(port))
            port = "2638";
        string connStr = string.Format("Provider=SAOLEDB.10;LINKS=tcpip(host={0},PORT={1});ServerName=EAGLESOFT;Integrated Security = True; User ID = dba; PWD = sql", ip, port);
        using (OleDbConnection conn = new OleDbConnection(connStr))
        {
            try
            {
                conn.Open();
                if (conn.State != System.Data.ConnectionState.Open)
                    // You could also implement a WHILE loop with a small delay (~1200ms) and try again to open the connection, with a counter to "fail" after a certain number (like 3) of attempts.
                    throw new Exception("Unable to open connection to database.");
                using (OleDbCommand cmd = new OleDbCommand("SELECT tran_num, provider_id, tran_date FROM transactions WHERE tran_date LIKE '2015-11-23%'", conn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                        Console.WriteLine("{0}|{1}|{2}", reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString());
            }
            catch (Exception connerr)
            { Debug.WriteLine(connerr.Message); }
            finally
            { conn.Close(); }
        }
        if (Debugger.IsAttached)
        {
            Console.ReadLine();
        }
    }
