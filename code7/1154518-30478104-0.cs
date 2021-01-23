    var fmts = new[] { "dd/MM/yy", "dd/MMM/yyyy", "dd-MM-yy"}; // Allowed formats
    DateTime dt;
    var valid1 = DateTime.TryParseExact("13/02/15", fmts, new System.Globalization.CultureInfo("en-us"), System.Globalization.DateTimeStyles.None, out dt);
    // true
    var valid2 = DateTime.TryParseExact("10/Apr/2012", fmts, new System.Globalization.CultureInfo("en-us"), System.Globalization.DateTimeStyles.None, out dt);
    // true
    var valid3 = DateTime.TryParseExact("23-02-10", fmts, new System.Globalization.CultureInfo("en-us"), System.Globalization.DateTimeStyles.None, out dt);
    // true
    var valid4 = DateTime.TryParseExact("01-30-15", fmts, new System.Globalization.CultureInfo("en-us"), System.Globalization.DateTimeStyles.None, out dt);
    // false
