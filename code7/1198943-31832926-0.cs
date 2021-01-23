    public partial class ProductField
    {
        public string ProductFieldID { get; set; }
        public string ProductTypeEn { get; set; }
        public string ProductTypeAr { get; set; }
        public string ProductFieldNameEn { get; set; }
        public string ProductFieldNameAr { get; set; }
        public string ProdcutFieldDiscriptionEn { get; set; }
        public string ProductFieldDiscriptionAr { get; set; }
        public string UserGroup { 
           get
           { 
                return (this.IsAdmin ? "1":"0") +
                       (this.IsBrending ? "1":"0") +
                       (this.IsMarketing ? "1":"0") + 
                       (this.IsServices ? "1":"0"); //You can use some other serialization pattern 
           }
        }
        public bool IsAdmin { get; set; }
        public bool IsBrending { get; set; }
        public bool IsMarketing { get; set; }
        public bool IsServices { get; set; }
        public string Status { get; set; }
    }
