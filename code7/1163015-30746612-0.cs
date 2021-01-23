	var data =
	(
		from s in File.ReadLines(filename)
		where s != null
		where s.Contains("ADD GTRX:")
		select new Gtrx
		{
			CellId = int.Parse(PullValue(s, "CELLID")),
			Freq = int.Parse(PullValue(s, "FREQ")),
			//TrxNo = int.Parse(PullValue(s, "TRXNO")),
			IsMainBcch = PullValue(s, "ISMAINBCCH").ToUpper() == "YES",
			Commabcch = new List<string> { PullValue(s, "ISMAINBCCH") },
			DEFINED_TCH_FRQ = null,
			TrxName = PullValue(s, "TRXNAME"),
		}
	).ToArray();
