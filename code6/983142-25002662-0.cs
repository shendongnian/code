    var list = new [] { 1, 3, 15, 16, 4, 27, 65, 2, 99, 3, 16, 21, 72, 1, 5, 7, 2, 8 };
    var search = new [] { 1, 2, 3, 4 };
    
    var group = new List<int>();
    var start = -1;
    for (var i=0; i < list.Length; i++) {
        if (search.Contains(list[i])) {
            if (!group.Any()) {
                start = i;
            }
            if (!group.Contains(list[i])) {
                group.Add(list[i]);
            }
            if (group.Count == search.Length) {
                Console.WriteLine(start+" - "+i);
                group.Clear();
                i = start + 1;
                start = -1;
            }
        }
    }
