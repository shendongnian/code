    static void MergeSort(int[] a, int start, int end)
    { 
        if (start != end)
        {
            int n = (start + end) / 2;
    
            MergeSort(a, start, n);         // <------------ HERE IS THE FIX
            MergeSort(a, n + 1, end);
    
            MainMerge(a, start, (n + 1), end);
        }
    }
