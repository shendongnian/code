    using System.Data.SqlClient;
    using DapperExtensions;
    
    namespace StackOverflowAnswer
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			using (var cn = new SqlConnection("Server=.;Database=NORTHWND;Trusted_Connection=True;"))
    			{
    				var list = cn.GetList<Products>(
    					Predicates.Field<Products>(f => f.Discontinued, Operator.Eq, false)
    				);
    			}
    		}
    
    		class Products
    		{
    			public int ProductId { get; set; }
    			public string ProductName { get; set; }
    			public bool Discontinued { get; set; }
    		}
        }
    }
