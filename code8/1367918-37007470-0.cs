    ItemList list = new ItemList();
    list.Items = new List<Item>();
    using (var reader = XmlReader.Create("test.xml"))
    {
        while (reader.ReadToFollowing("item"))
        {
            var inner = reader.ReadSubtree();
            var item = XElement.Load(inner);
            var type = item.Element("type");
            if (type.Value == "Car")
            {
                var car = new Car();
                car.Make = item.Element("make").Value;
                car.Registration = item.Element("registration").Value;
                list.Items.Add(car);
            }
            else if (type.Value == "Bicycle")
            {
                var bicycle = new Bicycle();
                bicycle.Make = item.Element("make").Value;
                bicycle.FrameSerialNumber = item.Element("frameSerialNo").Value;
                list.Items.Add(bicycle);
            }
        }
    }
