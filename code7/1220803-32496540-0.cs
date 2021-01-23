    var inLines = File.ReadAllText(IN_CSV).Split('\n');
	var outLines = new List<string>();
	outLines.Add(OUT_CSV_HEADER);
	foreach (var line in inLines)
	{
		if (line.Contains("Time,MW")) continue;
		List<string> ocl = BuildOutCsvLine(line);
		var oclFinal = "";
		ocl.ForEach(o => {
			oclFinal = string.Join(",", oclFinal, o);
		});
		System.Console.WriteLine(oclFinal);
	}
        private static List<string> BuildOutCsvLine(string inCsvLine)
        {
            var clearR = inCsvLine.Replace("\r", "");
            var clearN = clearR.Replace("\n", "");
            var inCsvData = clearN.Split(',');
            var timestamp = DateTime.ParseExact(inCsvData[0], "dd/MM/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
            var season = seasons.GetSeason(timestamp);
            var tod = timestamp.Hour.ToString();
            var wd = ((int)timestamp.GetWeekDayType()).ToString();
            var ssn = ((int)season.Id).ToString();
            return new List<string> { clearN, tod, wd, ssn };
        }
