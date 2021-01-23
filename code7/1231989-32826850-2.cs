    static void Main(string[] args)
    {
        // Get XML string from web
        var client = new WebClient();
        string xml = client.DownloadString("http://www.smartpost.ee/places.xml");
        // Create a serializer
        var serializer = new XmlSerializer(typeof(PlacesInfo));
        // Variable to hold all XML data
        PlacesInfo info;
        // Deserialize XML string to object
        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
        {
            info = (PlacesInfo) serializer.Deserialize(stream);
        }
        // Create delivery list
        var deliveryList = new List<Delivery>();
        // For each place
        foreach (var place in info.Places)
        {
            // Concatenate name, city, and address
            string address = string.Format("{0} {1} {2}", place.Name, place.City, place.Address);
            // Add new delivery
            var delivery = new Delivery(place.Id, address);
            deliveryList.Add(delivery);
            // Display to test
            Console.WriteLine(delivery.Id + " " + delivery.Address);
        }
        Console.ReadLine();
    }
