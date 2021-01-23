        List<int> diff = new List<int>();
        
        foreach (int num in list1)
        {
           if (!list2.Contains(num))
           {
             diff.Add(num);
           }
        }
    
        foreach (int num in list2)
        {
           if (!list1.Contains(num) && !diff.contains(num))
           {
              diff.Add(num);
           }
        }
