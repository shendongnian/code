    public interface TPH_IPriceList
    {
        IList<TPH_IPriceListItem> ListItems { get; set; }
    }
  
    public interface TPH_IPriceListItem
    {
        string DestCityName { get; set; }
        int StayDuration { get; set; }
        int LowestPrice { get; set; }
    }
    [DataContract(Name = "PriceList")]
    [KnownType(typeof(TPH_PriceListJsonItems))]
    public class TPH_PriceListJson : TPH_IPriceList
    {
        [DataMember]
        public IList<TPH_IPriceListItem> ListItems { get; set; }
        public TPH_PriceListJson()
        {
            ListItems = new TPH_PriceListJsonItems();
        }
    }
    [DataContract]
    public class TPH_PriceListJsonItem : TPH_IPriceListItem
    {
        [DataMember(Order = 1)]
        public string DestCityName { get; set; }
        [DataMember(Order = 2)]
        public int StayDuration { get; set; }
        [DataMember(Order = 3)]
        public int LowestPrice { get; set; }
    }
    [CollectionDataContract(Name = "ListItems", ItemName = "ListItem")]
    [KnownType(typeof(TPH_PriceListJsonItem))]
    public class TPH_PriceListJsonItems : List<TPH_IPriceListItem>
    {
    }
