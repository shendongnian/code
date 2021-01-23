    static void Main()
    {
    
        using(OleDbConnection cn = Connection())
        using(OleDbCommand cmd = new OleDbCommand("SELECT City FROM Employees", cn);
        {
             cn.Open();
             using(OleDbDataReader rdr = cmd.ExecuteReader())
             {
                 while (rdr.Read())
                 {
                    ....
                 }
             }
        }
        Console.ReadLine();
    
    }
