    public class ProductsVM
    {
      [Display(Name = "Sort by:")]
      public int? OrderBy { get; set; }
      public IEnumerable<SelectListItem> OrderList { get; set; }
      public int Page { get; set; }
      public int PageSize { get; set; }
      PagedList<Product> Products { get; set; }
    }
