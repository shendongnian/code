    [DataContract(Name = "PriceList")]
    [KnownType(typeof(TPH_PriceListJsonItems))]
    public class TPH_PriceListJson : TPH_IPriceList
    {
        [IgnoreDataMember]
        public TPH_IPriceListItems ListItems
        {
            get
            {
                return ListItemList;
            }
            set
            {
                var list = value as TPH_PriceListJsonItems;
                if (list == null)
                {
                    list = new TPH_PriceListJsonItems();
                    if (value != null)
                        list.AddRange(value);
                }
                ListItemList = list;
            }
        }
        [DataMember(Name = "ListItems")]
        TPH_PriceListJsonItems ListItemList { get; set; }
        public TPH_PriceListJson()
        {
            ListItemList = new TPH_PriceListJsonItems();
        }
    }
