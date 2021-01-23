    foreach (var img in itemViewModel.ItemImages.Where(i => ! i.Primary))
    {
        var itemImage = item.ItemImages.First(i => i.stream_id == img.stream_id);
        itemImage.Primary = img.Primary;
        itemImage.Caption = img.Caption;
    }
    
    await db.SaveChangesAsync();
    
    var primaryImage = itemViewModel.ItemImages.First(i => i.Primary);
    var itemImagePrimary = item.ItemImages.First(i => i.stream_id == primaryImage.stream_id);
    itemImagePrimary.Primary = primaryImage.Primary;
    itemImagePrimary.Caption = primaryImage.Caption;
    
    await db.SaveChangesAsync();
