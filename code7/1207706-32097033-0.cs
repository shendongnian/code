    foreach (var v in tmpList) {
        testCollection.Add(v);
        if (testCollection.Contains(v))
            Console.WriteLine("YES");
        else
            Console.WriteLine("NO");
    }
