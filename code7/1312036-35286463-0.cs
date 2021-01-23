    List<Test> lstTests = new lstTests();
    Test test1 = new Test();
    Test test2 = new Test();
    Test test3 = new Test();
    
    test1.Counter = 3;
    test2.Counter = 4;
    test3.Counter = 3;
    
    lstTests.Add(test1);
    lstTests.Add(test2);
    lstTests.Add(test3);
    
    
    var valMin = lstTests.Min(m => m.Counter);
    var results = source.Where(x => x.Counter == valMin).ToList();
