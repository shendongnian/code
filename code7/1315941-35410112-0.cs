    string sizeMsg = "";
    if (list1.Count != list2.Count)
        sizeMsg = String.Format("They have a different size, list1.Count:{0} list2.Count:{1}", list1.Count, list2.Count);
    int count = Math.Min(list1.Count, list2.Count);
    var differences = Enumerable.Range(0, count)
        .Select(index => new { index, d1 = list1[index], d2 = list2[index] })
        .Where(x => x.d1 != x.d2)
        .Select(x => String.Format("list1 has value {0} at index {1}, list2 has value {2} at index {1}"
            , x.d1, x.index, x.d2));
    string differenceMessage = String.Join(Environment.NewLine, differences);
