    // get the total amount for each date
    public static List<DateAmountList> GetTotalAmount()
    {
        List<DateAmountList> results = new List<DateAmountList>();
        using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DBPath))
        {
            results = conn.Query<DateAmountList>("SELECT Date, SUM(Amount) AS 'Amount' FROM DateAmountList GROUP BY Date");
        }
        return results;
    }
