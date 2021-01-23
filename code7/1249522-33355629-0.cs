            int[] a = { 1, 3, 9, 2, 7, 8, 9 };
            int[] b = { 120, 70, 76, 190, 300, 50, 40 };
            var sortedList = new SortedList<int,int>();
            for (int i = 0; i < a.Length; i++)
            {
                sortedList[b[i]] = a[i];        
            }
            Console.WriteLine(sortedList.Last().Value);    
