		  using System.Data.Entity;
		 namespace NorthWin
		 {		  
 			public partial class NorthwindEntities : DbContext
 			{
 				public NorthwindEntities(string connString)
 					: base(connString)
 				{
 				}
 			}
 		}
