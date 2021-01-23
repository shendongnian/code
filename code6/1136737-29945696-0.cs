    public partial class SearchedProductInternal : IProduct
        {
            public string ID
            {
                get { return ObjectIdField.ToString(); }
            }
            public string Name  {get;set;}
            public string DescriptionShort{get { return shortDescriptionField; }
            }
            public string DescriptionLong {get { return longDescriptionField; }
            }
}
