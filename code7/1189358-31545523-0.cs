    var tests = Enum.GetValues(typeof(Test_ID)).Cast<Test_ID>();
    
    var results = Enum.GetValues(typeof(Test_Result)).Cast<Test_Result>();
    
    var pairs = new List<Pair>();
    
    foreach(var test in tests)
    {
        foreach(var result in results)
        {
            pairs.Add(new Pair
                {
                    Test = test,
                    Result = result
                });
        }
    }
