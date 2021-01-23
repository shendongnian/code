    foreach(var item in list1)
    {
      list2.Add(new YourClassName2{Tag = item.Tag, Resim = item.Resim1});
      list2.Add(new YourClassName2{Tag = item.Tag, Resim = item.Resim2});
    }
