    var xs = new XmlSerializer(typeof(Vehicles));
    Vehicles vehicles;
            
    using (var fs = new FileStream("file.xml", FileMode.Open))
    {
        vehicles = (Vehicles)xs.Deserialize(fs);
    }
    foreach (var vehicle in vehicles.Vehicle)
    {
        Console.WriteLine(vehicle.GetType()); // Model
        Console.WriteLine(vehicle.Id);
    }
