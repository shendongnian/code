    ...
    foreach (var img in itemViewModel.Images)
    {
        var itemImage = item.ItemImages.First(i => i.stream_id == img.stream_id);
        itemImage.Caption = img.Caption;
    }
    await db.SaveChangesAsync();
    
    db.SetPrimaryItemImage(item.ItemId, itemViewModel.Images.First(i => i.Primary).stream_id);   
    ...
