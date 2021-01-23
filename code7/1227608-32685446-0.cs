    List<object> arr1 = new List<object> { "a", "b", "c" };
                List<object> arr2 = new List<object> { 3, 2, 4,5 };
                List<object> arr3 = new List<object> { "0", "1", "2", "3", "4" };
    
    
                var result = from x in arr1
                             from y in arr2
                             from z in arr3
                             select new { x = x, y = y,z=z };
    
                List<object[]> newList = new List<object[]>();
                
                foreach (var line in result)
                {
                    newList.Add(new object[] { line.x, line.y, line.z });                     
                }
    
                foreach (var obj in newList)
                {
                    foreach (var ele in obj)
                    {
                        Console.Write(ele.ToString() + " ");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
