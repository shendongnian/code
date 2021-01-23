    List<string> numLst = new List<string>();
    for (int i = 1; i <= 10000; i++)
    {
        code = "034" + rm2.Next(0, 7);
        num = code + rm.Next(0, 9) + rm.Next(0, 9) + rm.Next(0, 9) + rm.Next(0, 9) + rm.Next(0, 9) + rm.Next(0, 9) + rm.Next(0, 9) ;
        numLst.Add(num);
    }
    dataGrid1.ItemsSource = numLst;
