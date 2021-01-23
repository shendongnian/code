    public class Category
        {
            [JsonProperty(PropertyName = "yourDesiredNameInJsonRequest")]
            public virtual int CategoryID { get; set; }
            public virtual int ParentCategory { get; set; }
            [JsonProperty(PropertyName = "yourAnotherDesiredNameInJsonRequest")]
            public virtual string Name { get; set; }
    
            [MaxLength]
            public virtual string Description {get;set; }
            public virtual ICollection<Product> Products { get; set; }
        }
