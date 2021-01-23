    public class DetailPageViewModel
    {
        public string Verbiage { set; get; }
        public IEnumerable<CurrentProduct> CurrentProducts { get; set; }
    }
    public class CurrentProduct
    {
        public int TypeId { get; set; }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Length { get; set; }
        public string Sku { get; set; }
        public string Isbn { get; set; }
        public string Price { get; set; }
    }
