    public class MerchantModel
    {
        public int AppId { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
    public class MerchantViewModel
    {
        public List<MerchantModel> Merchants { get; set; }
    }
