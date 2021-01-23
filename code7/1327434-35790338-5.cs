    var results = new List<Tuple<int, int, int>>();
    for (int index1 = 0; index1 < list1.Count; index1++)
    {
        for (int index2 = 0; index2 < list2.Count; index2++)
        {
            if (list1[index1] == list2[index2])
            {
                results.Add(Tuple.Of(list1[index1], index1, index2);
            }
        }
    }
