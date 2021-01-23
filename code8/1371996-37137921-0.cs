    for (int i = 0; i < list1.Count; i++)
            {
                if (list2.Contains(list1[i]))
                {
                    list1.Remove(i);
                   // list2.Remove(list2.IndexOf(list1[i]));
                    i--;
                    counter++;
                }
