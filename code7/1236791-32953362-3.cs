	class Trade
	{
		public string Pair;
		public string StopLoss;
		// Other variables from trade tag would go here...
		// Function that can load trade objects from XML file into a list of Trade objects (List<Trade>)
		public static List<Trade> loadTrade(string xmlFilePath)
		{
			// Load your XML document given the path to the .xml file
			var doc = XDocument.Load(xmlFilePath);
			// For each trade element in the trades element
			var trades = (from trade in doc.Element("trades").Elements("trade")
						  select new Trade
						  {
							  // For each element in the trade element, put value in class variable
							  Pair = trade.Element("pair").Value,
							  StopLoss = trade.Element("stop-loss").Value
						  }).ToList<Trade>();
			return trades;
		}
	}
