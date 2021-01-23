    public static void AddStock (SQLiteConnection db, string symbol) {
        var s = new Stock { Symbol = symbol };
        db.Insert (s);
        Console.WriteLine ("{0} == {1}", s.Symbol, s.Id);
    }
