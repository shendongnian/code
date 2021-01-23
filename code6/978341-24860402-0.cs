        Int value1 =95478;
        List<int> listInts = new List<int>();
        while(value1 > 0)
        {
            listInts.Add(value1 % 10);
            value1 = value1 / 10;
        }
        listInts.Reverse();
        var result= listInts .ToArray();
