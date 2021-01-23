           List<int> l1 = new List<int>();
            l1.Add(1);
            l1.Add(2);
            l1.Add(3);
           List<int> l2 = new List<int>();
            l2.Add(2);
            l2.Add(4);
            IEnumerable<int> l3 = l2.Except(l1); // l3 will have 4
            IEnumerable<int> l4 = l1.Except(l2); //l4 will have 1,3
           
