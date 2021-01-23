    Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase("master");
    Sitecore.Data.Items.Item home = master.GetItem("/sitecore/content/home");
    Sitecore.Data.Items.Item sampleItem =
     master.GetItem("/sitecore/media library/images/sample");
    Sitecore.Data.Items.MediaItem sampleMedia =
     new Sitecore.Data.Items.MediaItem(sampleItem);
    Sitecore.Data.Fields.ImageField imageField = home.Fields["imagefield"];
    if (imageField.MediaID != sampleMedia.ID )
    {
     home.Editing.BeginEdit();
     imageField.Clear();
     imageField.Src = Sitecore.Resources.Media.MediaManager.GetMediaUrl(sampleMedia);
     imageField.MediaID = sampleMedia.ID;
     imageField.MediaPath = sampleMedia.MediaPath;
     if (!String.IsNullOrEmpty(sampleMedia.Alt))
     {
     imageField.Alt = sampleMedia.Alt;
     }
     else
     {
     imageField.Alt = sampleMedia.DisplayName;
     }
     home.Editing.EndEdit();
    }
