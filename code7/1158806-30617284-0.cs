	var gtrxs = new List<Gtrx>();
	using (StreamReader sr = File.OpenText(filename))
	{
		while ((s = sr.ReadLine()) != null)
		{
			if (s.Contains("ADD GCELL:"))
			{
				var gtrx = new Gtrx
									{
										CellId = int.Parse(PullValue(s, "CELLID")),
										Freq = int.Parse(PullValue(s, "FREQ")),
										TrxNo = int.Parse(PullValue(s, "TRXNO")),
										IsMainBcch = PullValue(s, "ISMAINBCCH").ToUpper() == "YES",
										TrxName = PullValue(s, "TRXNAME"),
									};
				gtrxs.Add(gtrx);
			}
		}
	}
	IEnumerable<int> freqValues = gtrxs.Where(x => x.CellId == 639 && x.IsMainBcch == false).Select(x => x.Freq);
	string result = String.Join(",", freqValues);
