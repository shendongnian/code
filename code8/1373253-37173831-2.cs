	using System;
	using System.Collections.Generic;
	using System.Linq;
	
	public class Program
	{
		
		class TableRow 
		{
			public int I {get;set;}
			public bool CheckboxField {get;set;}
			
			TableRow(int i)
			{
				this.I = i;
				this.CheckboxField = (i % 3 == 0); //in our demo, assume that some are already checked, some aren't
			}
			
			public static IEnumerable<TableRow> GenerateTableRows(int howMany)
			{
				for (int i=0; i<howMany; i++)
				{
					yield return new TableRow(i);
				}
			}
			
		}
		
		public static void Main()
		{
			new Program();
			Console.WriteLine("Done");
		}
		
		Program() 
		{
			ICollection<TableRow> myTable = new List<TableRow>(TableRow.GenerateTableRows(12));
			while (myTable.Count(x => !x.CheckboxField) > 0) //keep looping until we've processed all records
			{
				var randomRecord = GetRandomRecord(myTable);
				Console.WriteLine(randomRecord == null ? "No Matching Rows Exist" : randomRecord.I.ToString()); 
			}
		}
		
		TableRow GetRandomRecord(ICollection<TableRow> myTable)
		{
			var rnd = new Random(); //we could optionally provide this as a parameter too to avoid recreating each time
			var randomRecord = myTable
				.Where(x => !x.CheckboxField)
				.ToList()
				.OrderBy(x => rnd.Next())
				.FirstOrDefault();	
			if(randomRecord != null) //avoid issue if all items are checked
			{
				randomRecord.CheckboxField = true; //mark this record as having been processed
			}
			return randomRecord;
		}
		
	}
