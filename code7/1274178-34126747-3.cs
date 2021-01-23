	ObservableCollection<Cproducts> ResultantCollection = new ObservableCollection<Cproducts>();
	if(File.Exists(path + "\\YourXML.xml"))
	{
		XElement root = XElement.Load(path + "\\YourXML.xml");
		root.Element("Cproducts").Elements("Availability").All<XElement>(xe =>
		{
			ResultantCollection.AddAvailability(Availability av);
			return true;
		});
