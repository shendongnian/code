    public partial class product
    {
        public product(int id, string barcode, int companyId){
            ProductId = id;
            ProductBarcode = barcode;
            CompanyID = comanyId;
        }
       public int ProductID { get; set; }
       public string ProductBarcode { get; set; }
       public int CompanyID { get; set; }
    }
    public class ProductPlus :product
    {
        public ProductPlus(product p) : base(p.ProductID, p.ProductBarcode, p.CompanyID){
          //whatever else you want to do in the constructor.
        }
        public bool Restock { get; set; }
        public DateTime? DateSold { get; set; }        
    }
