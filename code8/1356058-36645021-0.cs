    List<Data> list = new List<Data>()
    {
        new Data { Key="A",Val=9 },
        new Data { Key="B",Val=1 },
        new Data { Key="D",Val=1 },
        new Data { Key="C",Val=1 },
        new Data { Key="E",Val=1 }
    };
    List<Data> list1 = new List<Data>();
    List<Data> list2 = new List<Data>();
    int i = 0;
    while (list.Any())
    {
        var max = list.Max(p => p.Val);
        var min = list.Min(p => p.Val);
        var maxItem = list.FirstOrDefault(p => p.Val == max);
        var minItem = list.FirstOrDefault(p => p.Val == min && max != min);
        if (maxItem == null)
        {
            if (list1.Sum(p => p.Val) < list1.Sum(p => p.Val))
                list1.Add(minItem);
            else
                list2.Add(minItem);
        }
        else if(minItem == null)
        {
            if (list1.Sum(p => p.Val) < list1.Sum(p => p.Val))
                list1.Add(maxItem);
            else
                list2.Add(maxItem);
        }
        else
        {
            if ((i++) % 2 == 0)
            {
                list1.Add(maxItem);
                list2.Add(minItem);
            }
            else
            {
                list2.Add(maxItem);
                list1.Add(minItem);
            }
        }
        list.Remove(minItem);
        list.Remove(maxItem);
    }
    var sumList1 = list1.Sum(p => p.Val);
    var sumList2 = list2.Sum(p => p.Val);
