    class Program
	{
		static void Main(string[] args)
		{
			test t = new test();
			List<Product> productList1 = new List<Product>();
			List<DifferentProduct> differentProductList = new List<DifferentProduct>();
			t.ProductListing(productList1, differentProductList);
		}
	}
	public class test
	{
		public void ProductListing<T, U>(List<T> list1, List<U> list2)
			where T : IProduct
			where U : IProduct
		{
		}
	}
	public abstract class Product : IProduct
	{
	  public int ID { get; set; }
	  public string ProductName{ get; set; }
	}
	public class DifferentProduct : IProduct
	{
	  public int ID{get; set;}
	}
	public interface IProduct
	{
		int ID { get; set; }
	}
