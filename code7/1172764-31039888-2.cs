    public static void PrintSum(int[] list)
    {
        // Define the end of the recursion 
        if (list.Count() > 2)
            // Copy the shorter list to PrintSum()
            PrintSum(list.Take(list.Count() - 1).ToArray());
    
        // Print the result of list AFTER shorter list is done
        System.Diagnostics.Debug.WriteLine(
            string.Format("{0} = {1}", string.Join("+ ", list), 
            list.Sum()));
    }
    public static void PrintSumReverse(int[] list)
    {
        // Print the result of list
        System.Diagnostics.Debug.WriteLine(
            string.Format("{0} = {1}", string.Join("+ ", list),
            list.Sum()));
    
        // Define the end of the recursion
        if (list.Count() > 2)
            // Copy the shorter list to PrintSum()
            PrintSum(list.Take(list.Count() - 1).ToArray());
    }
