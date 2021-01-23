            public enum SortType
            {
                 unsorted = 0,
    	         ascending = 1,
                 descending = 2
            }
    
            public static SortType IsArraySorted(int[] numbers)
            {
                bool ascSorted = true;
                bool descSorted = true;
    
                List<int> asc = new List<int>(numbers);            
    
                asc.Sort();
    
                for (int i = 0; i < asc.Count; i++)
                {
                    if (numbers[i] != asc[i]) ascSorted = false;
                    if (numbers[asc.Count - 1 - i] != asc[i]) descSorted = false;
                }
    
                return ascSorted ? SortType.ascending : (descSorted? SortType.descending : SortType.unsorted);
            }
