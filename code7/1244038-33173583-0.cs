    Sitecore.Data.Items.Item sampleItem = Sitecore.Context.Database.GetItem("/sitecore/media library/Files/yourhtmlfile");
    Sitecore.Data.Items.Item sampleMedia = new Sitecore.Data.Items.MediaItem(sampleItem);
    using(var reader = new StreamReader(MediaManager.GetMedia(sampleMedia).GetStream().Stream))
    {
        string text = reader.ReadToEnd();
    }
