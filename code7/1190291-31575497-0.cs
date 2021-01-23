    String Queryname = TextBox1.Text
    Console.WriteLine("y: {0}", liveData.Tables["Players"].Rows.Count); //Shows full table
        DataRow[] foundRows;
        foundRows = liveData.Tables["Players"].Select("FName like " + Queryname);
        foreach (DataRow dr in foundRows)
        {
            Console.WriteLine("Index is " + dr.Table.Rows.IndexOf(dr));
        }
