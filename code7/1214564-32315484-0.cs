    public class AlbumModel
    {
        [JsonProperty(PropertyName = "max_car")]
        public int MaxChars { get; private set; }
        [JsonProperty(PropertyName = "trans_img")]
        public string TransparentImage { get; private set; }
        [JsonProperty(PropertyName = "product_type")]
        public string ProductType { get; private set; }
        [JsonProperty(PropertyName = "obj")]
        public AlbumInfo Object { get; private set; }
        [JsonProperty(PropertyName = "show_description")]
        public bool ShowProductDescription { get; private set; }
        public AlbumModel(AlbumVO album)
        {
            MaxChars = album.maxCharsProjecName;
            TransparentImage = album.Transparent_Image;
            ShowProductDescription = album.Show_Product_Description;
            ProductType = "Album";
            Object = new AlbumInfo(album);
        }
    }
