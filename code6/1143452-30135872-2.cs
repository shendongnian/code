        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Item>));
        // And later
        foreach (Item item in (List<Item>)serializer.ReadObject(stream))
        {
            Item.Items.Add(item);
        }
