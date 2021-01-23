        List<int> list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        var outputList = new List<int>();
        foreach (int i in list)
        {
            if (i == 2)
            {
                outputList.Add(666);
                //do something to refresh the foreach loop
            }
            outputList.Add(list[i]);
        }
