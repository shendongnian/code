    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var ds = new DataSet();
    			var customersTable = ds.Tables.Add("Customers");
    			customersTable.Columns.AddRange("FirstName", "LastName", "Id", "Address");
    			customersTable.Rows.Add("Bob", "Sagget", 1, "123 Mockingbird Lane");
    			customersTable.Rows.Add("John", "Doe", 2, "1600 Pennsylvanie Ave");
    			customersTable.Rows.Add("Jane", "Doe", 3, "100 Main St");
    
    			Console.WriteLine(ds.ToPrettyString());
    			Console.WriteLine("Press any key to exit.");
    			Console.ReadKey();
    		}
    	}
    
    	static class ExtensionMethods
    	{    
    		public static string ToPrettyString(this DataSet ds)
    		{
    			var sb = new StringBuilder();
    			foreach (var table in ds.Tables.ToList())
    			{
    				sb.AppendLine("--" + table.TableName + "--");
    				sb.AppendLine(String.Join(" | ", table.Columns.ToList()));
    				foreach (DataRow row in table.Rows)
    				{
    					sb.AppendLine(String.Join(" | ", row.ItemArray));
    				}
    				sb.AppendLine();
    			}
    			return sb.ToString();
    		}
    
    		public static void AddRange(this DataColumnCollection collection, params string[] columns)
    		{
    			foreach (var column in columns)
    			{
    				collection.Add(column);
    			}
    		}		
    
    		public static List<DataTable> ToList(this DataTableCollection collection)
    		{
    			var list = new List<DataTable>();
    			foreach (var table in collection)
    			{
    				list.Add((DataTable)table);
    			}
    			return list;
    		}
    
    		public static List<DataColumn> ToList(this DataColumnCollection collection)
    		{
    			var list = new List<DataColumn>();
    			foreach (var column in collection)
    			{
    				list.Add((DataColumn)column);
    			}
    			return list;
    		}
    	}
    }
