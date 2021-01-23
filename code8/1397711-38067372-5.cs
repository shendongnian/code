    [JsonConverter(typeof(PageConverter<LinksResult, LinkData>))]
    public class LinksResult : IPage<LinkData>
    {
        public int Count { get; set; }
        public List<LinkData> PageItems { get; set; }
    }
