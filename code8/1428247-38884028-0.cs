    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Server;
    using System.Collections;
    
    namespace ExtractMdxParts
    {
    	public partial class UserDefinedFunctions
    	{
    		public class EventData
    		{
    			public SqlString Product;
    			public SqlString CategoryFilter;
    			public SqlString Group;
    			public SqlString ExtraData;
    		}
    
    		[Microsoft.SqlServer.Server.SqlFunction(
    		FillRowMethodName = "FillRow",
    		TableDefinition = "Product nvarchar(128), CategoryFilter nvarchar(128),	Group nvarchar(128), Extradata nvarchar(MAX)",
    		IsDeterministic = true)]
    
    		public static IEnumerable ExtractParts([SqlFacet(MaxSize = -1)] String MdxString)
    		{
    			string[] parts = MdxString.Split(".".ToCharArray(), 4, StringSplitOptions.None);
    			if (parts.Length < 3)
    			{
    				return null;
    			}
    
    			List<EventData> x = new List<EventData> { };
    			char[] trimChars = "[]".ToCharArray();
    			EventData y = new EventData { Product = parts[0].Trim(trimChars), CategoryFilter = parts[1].Trim(trimChars), Group = parts[2].Trim(trimChars) };
    
    			if (parts.Length == 4)
    			{
    				y.ExtraData = string.Join(",", parts[3].Split(".".ToCharArray()).Select(p => p.Substring(1).Trim(trimChars)));
    			}
    
    			x.Add(y);
    
    			return x;
    
    		}
    
    		public static void FillRow(object eventData, out SqlString product, out SqlString categoryFilter, out SqlString group, out SqlString extraData)
    		{
    			//I'm using here the FileProperties class defined above
    			EventData ed = (EventData)eventData;
    			product = new SqlString(ed.Product.ToString());
    			categoryFilter = new SqlString(ed.CategoryFilter.ToString());
    			group = new SqlString(ed.Group.ToString());
    			extraData = new SqlString(ed.ExtraData.ToString());
    		}
    
    	}
    
    }
