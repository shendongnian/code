    int[] arr = new int[] { 1, 2, 1, 4, 5, 1, 2, 2, 2 };
    int?[] arr2 = new int?[arr.Length];
    arr2.ToList().ForEach(i => i = null);
    int occurrenceLimit = 2;
    var ints = arr.GroupBy(x => x).Select(x => x.Key).ToList();
    ints.ForEach(i => {
       int ndx = 0;
       for (int occ = 0; occ < occurrenceLimit; occ++){
            ndx = arr.ToList().IndexOf(i, ndx);
            if (ndx < 0) break;
            arr2[ndx++] = i;
       }
    });
    List<int?> intConverted = arr2.ToList();
    intConverted.RemoveAll(i => i.Equals(null));
