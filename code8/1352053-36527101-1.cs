    var obj = new root();
    obj.items = new Items
    {
        averageItemLevel = 42,
        feet = new Item { armor = 4242 },
        chest = new Item { name = "super chest" }
    };
    
    var ser = new DataContractJsonSerializer(typeof(root));
    
    using (var ms = new MemoryStream())
    {
        ser.WriteObject(ms, obj);
    
        Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        Console.WriteLine("and deserialize");
    
        ms.Position = 0;
        var deserializeObject = (root) ser.ReadObject(ms);
                   
        Console.WriteLine(deserializeObject.items.feet.armor);
    }
