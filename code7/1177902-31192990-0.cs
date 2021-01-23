	void Main()
	{
		var str = @"
		<root>
		<property>
		<price>2080000</price>
		<country>France</country>
		<currency>euro</currency>
		<locations>
			<location_9>Ski</location_9>
			<location_16>50km or less to airport</location_16>
			<location_17>0-2KM to amenities</location_17>
		</locations>
		<secondaryproptypes>
			<secondaryproptypes_1>Holiday Home</secondaryproptypes_1>
		</secondaryproptypes>
		<features>
			<features_30>Woodburner(s)</features_30>
			<features_9>Private parking</features_9>
			<features_23>Mountain view</features_23>
			<features_2>Mains Drains</features_2>
		</features></property>
		</root>";
		var document = XDocument.Parse(str);
		var properties = 
			(from p in document.Root.Elements("property")
						select new Property
						{
		
							price = Convert.ToDecimal(p.Element("price").Value),
							country = p.Element("country").Value,
							currency = p.Element("currency").Value,
							locations = new List<Location>(from l in p.Element("locations").Elements()
														select new Location
														{
															location = (string)l
														})
						}
		
							).ToList()
							.Dump();
	}
	public class Property
    {
        public decimal price { get; set; }
        public string country { get; set; }
        public string currency { get; set; }
    public List<Location> locations { get; set; }
    }
	
	public class Location
    {
        public string location { get; set; }
    }
