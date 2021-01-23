    using (SQLiteConnection c = new SQLiteConnection("Data Source=stefanauto.psa;Version=3;"))
    {
        c.Open();
        using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
        {
            //your code
        }
    }
