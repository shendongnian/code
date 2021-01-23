        List<double> test = new List<double>(); 
        List<double> theOneList = wqList.Concat(rList).Concat(eList).ToList();
        theOneList.Add(0);
        theOneList = theOneList.OrderByDescending(z => z).ToList(); // you need to set the list after ordering; or the old list will not change
        for (int i = 0; i < 5; i++) // change variables to integer, do you know that at least 8 values exists in theOneList?
        {
            test.Add(theOneList[i + 2] - theOneList[i + 3]);
            Console.WriteLine(test[i]);
        }
