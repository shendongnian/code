    ItemList list = new ItemList();
    list.Items = new List<Item>();
    var carSerializer = new XmlSerializer(typeof(Car));
    var bicycleSerializer = new XmlSerializer(typeof(Bicycle));
    using (var reader = XmlReader.Create("test.xml"))
    {
        while (reader.ReadToFollowing("item"))
        {
            var inner = reader.ReadSubtree();
            var item = XElement.Load(inner);
            var type = item.Element("type");
            if (type.Value == "Car")
            {
                var car = (Car)carSerializer.Deserialize(item.CreateReader());
                list.Items.Add(car);
            }
            else if (type.Value == "Bicycle")
            {
                var bicycle = (Bicycle)bicycleSerializer.Deserialize(item.CreateReader());
                list.Items.Add(bicycle);
            }
        }
    }
