    string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\test.xlsx;Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1""";
    using (DbClass db = new DbClass(connString))
    {
        var x = db.dataReader("SELECT * FROM [Sheet1$]");
        while (x.Read())
        {
            for (int i = 0; i < x.FieldCount; i++)
                Console.Write(x[i] + "\t");
            Console.WriteLine("");
        }
    }
