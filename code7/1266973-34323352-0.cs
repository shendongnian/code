    ...
    string new_value = "New title for the image";
    PropertyItem item_title = (PropertyItem)FormatterServices.GetUninitializedObject(typeof(PropertyItem));
    item_title.Id = 0x9c9b; // XPTitle 0x9c9b
    item_title.Type = 1;
    item_title.Value = System.Text.Encoding.Unicode.GetBytes(new_value + "\0");
    item_title.Len = item_title.Value.Length;
    image.SetPropertyItem(item_title);
    PropertyItem item_title2 = (PropertyItem)FormatterServices.GetUninitializedObject(typeof(PropertyItem));
    item_title2.Id = 0x010e; // ImageDescription 0x010e
    item_title2.Type = 2;
    item_title2.Value = System.Text.Encoding.UTF8.GetBytes(new_value + "\0");
    item_title2.Len = item_title2.Value.Length;
    image.SetPropertyItem(item_title2);
    
    image.Save("new_filename.jpg", ImageFormat.Jpeg)
    image.Dispose();
    ...
