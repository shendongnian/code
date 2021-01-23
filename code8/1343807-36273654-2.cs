    public static void SearchLog(Car search)
            {
                var resultList = myList.Where(x => x.Model == search.Model).ToList();
                int i = 1;
                foreach (var car in resultList)
                {
                    Console.WriteLine("Result {0} : {1}", i++, myList[i].ToString());
                }
            }
