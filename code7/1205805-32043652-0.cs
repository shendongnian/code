    string raw =
    @"50|Carbon|Mercury|P:4;P:00;P:1
    90|Oxygen|Mars|P:10;P:4;P:00
    90|Serium|Jupiter|P:4;P:16;P:10
    85|Hydrogen|Saturn|P:00;P:10;P:4";
    		
	string[] splits = raw.Split(
        new string[] { "|", ";", "\n" },
        StringSplitOptions.None
    );
    		
    foreach (string p in splits.Where(s => s.ToUpper().StartsWith(("P:"))).Distinct())
	{
		Console.WriteLine(
            string.Format("{0} - {1}",
                p,
                splits.Count(s => s.ToUpper() == p.ToUpper())
            )
        );
   	}
