    using(OleDbConnection cnn = new OleDbConnection("......"))
    {
        cnn.Open();
        DataTable dt = cnn.GetSchema("TABLES");
        foreach(DataRow r in dt.Rows)
            Console.WriteLine(r["TABLE_NAME"].ToString());
    }
