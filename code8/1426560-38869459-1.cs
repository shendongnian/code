    using System;
    using System.Data.SqlClient;
    using System.Linq.Expressions;
    using Dapper.Extensions.Linq.Builder;
    using Dapper.Extensions.Linq.Core;
    using DapperExtensions;
    
    namespace StackOverflowAnswer
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			using (var cn = new SqlConnection("Server=.;Database=NORTHWND;Trusted_Connection=True;"))
    			{
    				Expression<Func<Products, bool>> filter = p => !p.Discontinued;
    				var queryFilter = QueryBuilder<Products>.FromExpression(filter);
    
    				var list = cn.GetList<Products>(
    					queryFilter
    				);
    			}
    		}
    
    		class Products : IEntity
    		{
    			public int ProductId { get; set; }
    			public string ProductName { get; set; }
    			public bool Discontinued { get; set; }
    		}
        }
    }
