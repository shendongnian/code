    public static void Main()
    {
        float f;
        using(var conn = new SqlConnection("Server=.;Integrated Security=SSPI"))
        {
            conn.Open();
            f = ExecuteQueryWithResult_fl(conn, "select cast(1.23 as float(24))");
        }
        Console.WriteLine(f); // 1.23
    }
