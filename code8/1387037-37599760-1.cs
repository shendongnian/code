    reader.ReadToFollowing("OrderNumber");
    plist.OrderNumber = reader.ReadElementContentAsString();
    reader.ReadToFollowing("OrderQty");
    plist.OrderQty = reader.ReadElementContentAsInt();
    reader.ReadToFollowing("Items");
    using (var innerReader = reader.ReadSubtree())
    {
        while (innerReader.ReadToFollowing("PN"))
        {
            var item = new OrderItem();
            item.PN = innerReader.ReadElementContentAsString();
            reader.ReadToFollowing("Color");
            item.Color = innerReader.ReadElementContentAsString();
            plist.OrderItems.Add(item);
        }
    }
    reader.ReadToFollowing("foo");
    var foo = reader.ReadElementContentAsString();
