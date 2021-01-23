    class Program
    {
        static void CompareRows(DataTable table1, DataTable table2)
        {
	        foreach (DataRow row1 in table1.Rows)
	        {
	            foreach (DataRow row2 in table2.Rows)
	            {
		            var array1 = row1.ItemArray;
		            var array2 = row2.ItemArray;
		            if (array1.SequenceEqual(array2))
		            {
		                Console.WriteLine("Equal: {0} {1}",
			            row1["Drug"], row2["Drug"]);
		            }
		            else
		            {
		                Console.WriteLine("Not equal: {0} {1}",
			            row1["Drug"], row2["Drug"]);
		            }
	            }
	        }
        }
        static DataTable GetTable1()
        {
	        DataTable table = new DataTable();
	        table.Columns.Add("Dosage", typeof(int));
	        table.Columns.Add("Drug", typeof(string));
	        table.Columns.Add("Patient", typeof(string));
	        table.Rows.Add(25, "Indocin", "David");
	        table.Rows.Add(50, "Enebrel", "Cecil");
	        return table;
         }
         static DataTable GetTable2()
         {
	         DataTable table = new DataTable();
	         table.Columns.Add("Dosage", typeof(int));
	         table.Columns.Add("Drug", typeof(string));
	         table.Columns.Add("Patient", typeof(string));
	         table.Rows.Add(21, "Combivent", "Janet");
	         table.Rows.Add(50, "Enebrel", "Cecil");
	         table.Rows.Add(10, "Hydralazine", "Christoff");
	         return table;
         }
         static void Main()
         {
	         CompareRows(GetTable1(), GetTable2());
         }
     }
