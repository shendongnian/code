    string[] d = { "Law & Order Special Victims Unit S05E21 Criminal", "Law & Order Special Victims Unit.S05E21.Criminal", "Law.&.Order.Special.Victims.Unit.S05E21.Criminal", "Law & Order Special Victims Unit - S05E21 - Criminal" };
    var r = new System.Text.RegularExpressions.Regex(@"(.*?)\s*[\.-]?\s*S(\d+)E(\d+)\s*[\.-]?\s*(.*)");
    foreach (var v in d)
    {
        var match = r.Match(v);
        foreach (var g in match.Groups)
            Console.WriteLine(g);
        Console.WriteLine();
    }
