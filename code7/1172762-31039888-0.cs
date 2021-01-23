    public static void PrintSum(int[] list)
    {
        // Copy the shorter list to PrintSum()
        if (list.Count() > 2)
            PrintSum(list.Take(list.Count() - 1).ToArray());
    
        // Print the result of list AFTER shorter list is done
        System.Diagnostics.Debug.WriteLine(
            string.Format("{0} = {1}", string.Join("+ ", list), 
            list.Sum()));
    }
