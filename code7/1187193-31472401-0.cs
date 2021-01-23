    var time = "14:00";
    var hour = Int32.Parse(time.Substring(0, 2));
    var minute = Int32.Parse(time.Substring(3, 2));
    var results = db.Table.Where(item =>
        SqlFunctions.DateName("hh", item.DateTimeProperty) == hour &&
        SqlFunctions.DateName("n", item.DateTimeProperty) == minute);
