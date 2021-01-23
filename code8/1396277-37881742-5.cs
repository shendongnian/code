    House myHouse = new House();
    myHouse.Number = 13;
    
    myHouse.Rooms = new List<Room>();
    
    Room room1 = new Room();
    room1.Name = "some room";
    room1.Floor = 0;
    myHouse.Rooms.Add(room1);
    
    Room room2 = new Room();
    room2.Name = "other room";
    room2.Floor = 3;
    myHouse.Rooms.Add(room2);
    
    Bathroom bathroom = new Bathroom();
    bathroom.Name = "Bathroom";
    bathroom.Floor = 2;
    bathroom.IsWet = true;
    myHouse.Rooms.Add(bathroom);
    
    JsonSerializerSettings settings = new JsonSerializerSettings();
    settings.TypeNameHandling = TypeNameHandling.Auto;
    
    string json = JsonConvert.SerializeObject(myHouse, settings);
    Console.WriteLine("Serialize finished!");
    
    House house = JsonConvert.DeserializeObject<House>(json, settings);
    Console.WriteLine($"House number: {house.Number}; Total rooms: {house.Rooms.Count}");
    
    foreach (Room room in house.Rooms)
    {
    	if (room is Bathroom)
    	{
    		var temp = room as Bathroom;
    		Console.WriteLine($"Room name: {temp.Name}, wet: {temp.IsWet}");
    	}
    	else
    	{
    		Console.WriteLine($"Room name: {room.Name}");
    	}
    }
    Console.WriteLine("Deserialize finished!");
    
    Console.ReadLine();
