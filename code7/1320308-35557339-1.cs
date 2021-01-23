     List<Märk> newklädDataList = new List<Märk>();
                 
    
                // Add newklädDataList to the list.
                newklädDataList.Add(new Märk() { Value = "regular seat", Id = 9 });
                newklädDataList.Add(new Märk() { Value = "crank arm", Id = 5 });
                newklädDataList.Add(new Märk() { Value = "shift lever", Id = 6 }); ;
                // Name intentionally left null.
                newklädDataList.Add(new Märk() { Id = 2 });
                newklädDataList.Add(new Märk() { Value = "banana seat", Id = 4 });
                newklädDataList.Add(new Märk() { Value = "cassette", Id = 3 });
    
                Console.WriteLine("\nBefore sort:");
                foreach (Märk märk in newklädDataList)
                {
                    Console.WriteLine(märk);
                }
    
                Console.WriteLine("----------------------------------------------------------------------------------------\r\r\r");
                newklädDataList.Sort();
    
    
                Console.WriteLine("\nAfter sort by Märk Id:");
                foreach (Märk märk in newklädDataList)
                {
                    Console.WriteLine(märk);
                }
    
                Console.ReadLine();
