    static void PrintInventory(List<Dept> s,string userInputDepartmentName)
    {
        if(s == null && s.Count <= 0)
            return;
        foreach (Dept d in s)
        {
            if(d.Name.Equals(userInputDepartmentName))
            {
               Console.WriteLine("Dept: {0,-20} [{1} items]", d.Name, d.NumItems);
               for (int i = 0; i < d.NumItems; i++)
                Console.WriteLine("{0,-15} {1,4} {2,7:$,##0.00}", d.GetItem(i).Name,d.GetItem(i).Quan, d.GetItem(i).PriceEach);
            }
         }
    }
