    foreach (DataRow row in MyTable.Rows) // Loop over the rows.
            {
                Console.WriteLine("--- Row ---");
                if (row["Price"] > 6)
                {
                    foreach (var item in row.ItemArray) // Loop over the items.
                    {
                        Console.Write("Item: "); 
                        Console.WriteLine(item);
                    }
                }
            }
