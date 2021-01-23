    [DataContract]
    public class Set
    {
        public Set(string ImageSize, string setImageRarity)
        {
            setImageUrl = String.Format("http://gatherer.wizards.com/Handlers/Image.ashx?type=symbol&set={0}&size={1}&rarity={2}", gathererCode, ImageSize, setImageRarity);
        }
        [DataMember(Name = "setImageUrl")]
        public string setImageUrl { get; set; }
        [DataMember(Name = "code")]
        public string code { get; set; }
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "type")]
        ...
