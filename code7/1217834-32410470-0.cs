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
