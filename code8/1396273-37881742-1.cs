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
    
    // Serialize object to string
    string json = JsonConvert.SerializeObject(myHouse);
    Console.WriteLine("Serialize finished!");
    
    // Convert the string back to object
    House house = JsonConvert.DeserializeObject<House>(json);
    Console.WriteLine($"House number: {house.Number}; Total rooms: {house.Rooms.Count}");
    Console.WriteLine("Deserialize finished!");
    
    Console.ReadLine();
