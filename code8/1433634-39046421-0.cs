    public class ProductdiscountapplyEntity //1 10 1.2 10 2 20 1.2 20 
    {
      public string _productid;
      public string _discount;
      public ProductdiscountapplyEntity(string productid, string discount)
      {
        _discount = discount;
        _productid = productid;
      }
    }
    public class members // 1 1.2 2 2.2
    {
      public string _Productid;
      public string _assproduct;
      public members(string Productid, string assproduct)
      {
        _Productid = Productid;
        _assproduct = assproduct;
      }
    }
    public class Productdiscount
    {
      string _ProductidinPDtag; // 1 2
      string _discPercent; // 10 20
      public Productdiscount(string ProductidinPDtag, string discPercent)
      {
        _ProductidinPDtag = ProductidinPDtag;
        _discPercent = discPercent;
      }
    }
    static class Program
    {
      static void Main(string[] args)
      {
        List<Productdiscount> _objProductdiscount = new List<Productdiscount>();
        _objProductdiscount.Add(new Productdiscount("1", "10%"));
        _objProductdiscount.Add(new Productdiscount("1", "20%"));
        _objProductdiscount.Add(new Productdiscount("2", "20%"));
        List<members> _objmembers = new List<members>();
        _objmembers.Add(new members("1", "1.2"));
        _objmembers.Add(new members("1", "2.2"));
        _objmembers.Add(new members("2", "3.2"));
        List<ProductdiscountapplyEntity> _objProductdiscountapplyEntity = new List<ProductdiscountapplyEntity>();
        var myassprod = (_objmembers.Where(c => c._Productid == "1").Take(1).Select(c => c._assproduct)).FirstOrDefault();
      }
    }
