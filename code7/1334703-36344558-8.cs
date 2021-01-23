    // Get the APEv2 tag if it exists.
    TagLib.Ape.Tag ape_tag = (TagLib.Ape.Tag)file.GetTag(TagLib.TagTypes.Ape, true);
    
    if(ape_tag != null) {
        ape_tag.SetValue("MP3GAIN_MINMAX", value);
    }
    file.Save();
