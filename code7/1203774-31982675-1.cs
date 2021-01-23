      IEnumerable<int> e1 = l2.Except(l1);   
      IEnumerable<int> e2 = l1.Except(l2);
        List<int> l3 = new List<int>();
        foreach (var item in e1)
        {
            l3.Add(item);
        }
        foreach (var item in e2)
        {
            l3.Add(item);
        }
