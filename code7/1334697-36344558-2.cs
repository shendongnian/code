    // Get the APEv2 tag if it exists.
    TagLib.Ape.Tag ape_tag = (TagLib.Ape.Tag)file.GetTag(TagLib.TagTypes.Ape, false);
    
    if(ape_tag != null) {
        // Get the item.
        TagLib.Ape.Item item = ape_tag.GetItem("MP3GAIN_MINMAX");
        if (item != null) {
            Console.Log(item.ToStringArray());
        }
    }
