    var list = new List<myClass>();
    list.Add(new myClass(120, 796, new DateTime(2015, 09, 04, 18, 00, 53)));
    list.Add(new myClass(120, 967, new DateTime(2015, 09, 04, 18, 03, 51)));
    list.Add(new myClass(119, 669, new DateTime(2015, 09, 04, 17, 45, 56)));
    list.Add(new myClass(119, 955, new DateTime(2015, 09, 04, 17, 42, 55)));
    list.Add(new myClass(119, 100, new DateTime(2015, 09, 04, 17, 41, 53)));
    list.Add(new myClass(116, 384, new DateTime(2015, 09, 04, 17, 01, 01)));
    list.Add(new myClass(116, 155, new DateTime(2015, 09, 04, 17, 00, 59)));
    list.Add(new myClass(116, 517, new DateTime(2015, 09, 04, 17, 00, 58)));
    list.Add(new myClass(113, 109, new DateTime(2015, 09, 04, 16, 02, 53)));
    list.Add(new myClass(113, 111, new DateTime(2015, 09, 04, 16, 00, 51)));
    list.Add(new myClass(107, 603, new DateTime(2015, 09, 04, 13, 45, 59)));
    var grouped = list.GroupBy(t =>
        t.PushedAt.ToString("yyyyMMddHH") +
        ((int)(t.PushedAt.Minute / 5)).ToString("00")
    );
    foreach (var g in grouped) {
        Console.WriteLine(g.Key);
        foreach (var itm in g) {
            Console.WriteLine(String.Format("{0}\t{1}\t{2}", itm.CId, itm.NID, itm.PushedAt));
        }
    }
