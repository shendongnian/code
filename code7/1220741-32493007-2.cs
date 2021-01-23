    [JsonIgnore]
    public List<Media> Images
    {
        get { return new List<Media> { new Media{..}, new Media{..} }; }
        set { AddImages(value); }
    }
    [JsonProperty("Images")] // Could be private
    Media [] ImagesArray
    {
        get { return Images.ToArray(); }
        set { AddImages(value); }
    }
