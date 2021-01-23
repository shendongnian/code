	var gtrxDict = new Dictionary<int, Gtrx>();
	using (StreamReader sr = File.OpenText(filename))
	{
	  while ((s = sr.ReadLine()) != null)
	  {
		if (s.Contains("ADD GTRX:"))
		{
		  int cellID = int.Parse(PullValue(s, "CELLID"));
		  Gtrx gtrx;
		  if(gtrxDict.TryGetValue(cellID, out gtrx)) // Found previous one
			gtrx.DEFINED_TCH_FRQ += "," + int.Parse(PullValue(ss, "FREQ"));
		  else // First one for this ID, so create a new object
			gtrxDict[cellID] = new Gtrx
			{
			  CellId = cellID,
			  Freq = int.Parse(PullValue(s, "FREQ")),
			  IsMainBcch = PullValue(s, "ISMAINBCCH").ToUpper() == "YES",
			  Commabcch = new List<string> { PullValue(s, "ISMAINBCCH") },
			  DEFINED_TCH_FRQ = int.Parse(PullValue(ss, "FREQ")).ToString(),
			  TrxName = PullValue(s, "TRXNAME"),
			};
		}
	  }
	}
