    public partial class ProductField
    {
        public string ProductFieldID { get; set; }
        public string ProductTypeEn { get; set; }
        public string ProductTypeAr { get; set; }
        public string ProductFieldNameEn { get; set; }
        public string ProductFieldNameAr { get; set; }
        public string ProdcutFieldDiscriptionEn { get; set; }
        public string ProductFieldDiscriptionAr { get; set; }
        public string UserGroupSerialized { 
           get
           { 
                JsonConvert.SerializeObject(UserGroups, Formatting.Indented);
           }
        }
        public IList<KeyValuePair<string,bool>> UserGroups { get; set; }
        public string Status { get; set; }
    }
