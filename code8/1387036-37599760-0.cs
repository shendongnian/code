    reader.ReadToFollowing("OrderNumber");
    plist.OrderNumber = reader.ReadElementContentAsString();
    reader.ReadToFollowing("OrderQty");
    plist.OrderQty = reader.ReadElementContentAsInt();
    while (reader.ReadToFollowing("PN"))
    {
        var item = new OrderItem();
        item.PN = reader.ReadElementContentAsString();
        reader.ReadToFollowing("Color");
        item.Color = reader.ReadElementContentAsString();
        plist.OrderItems.Add(item);
    }
