    Console.Write("Keyword: ");
    var keyword = Console.ReadLine() ?? "";
	using (var sr = new StreamReader("")) {
		while (!sr.EndOfStream) {
			var line = sr.ReadLine();
			if (String.IsNullOrEmpty(line)) continue;
			if (line.IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0) {
				Console.WriteLine(line);
			}
		}
	}
