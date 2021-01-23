    public class PRODUCTS
    {
    public int Id { get; set; }
    [ForeignKey("ProductViewModels")]
    public string PRODUCT_CODE { get; set; }
    public string DESCRIPTION { get; set; }
    public byte LAW { get; set; }
    public virtual ICollection<ProductViewModel> ProductViewModels {get; set;}
    }
