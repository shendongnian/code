    //Get the Image from /sitecore/media library/Images/Test
    Sitecore.Data.Items.MediaItem imageItem = Sitecore.Context.Database.GetItem("{AEBB3071-3462-405C-9CD3-A2B515B343D1}")
    //Edit   
    CurrentItem.Editing.BeginEdit();
    var imageField = CurrentItem.Fields["image"] as ImageField;
    imageField.MediaID = imageItem.ID;
    imageField.MediaPath = imageItem.MediaPath;
    CurrentItem.Editing.EndEdit();
