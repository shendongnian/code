    var dic = new SortedDictionay<int,string>();
    dic.Add(0,"First Item");
    dic.Add(1,"Second Item");
    dic.Items.First(); // returns first item
    dic.Remove(0);
    dic.Items.First(); // returns second item
