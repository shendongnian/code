        var lstConstant = "1,2,3,4,".Split(new string[] { "," },
                           StringSplitOptions.RemoveEmptyEntries).ToList();
        List<SampleExpression> lst = new List<SampleExpression>();
        lst.Add(new SampleExpression { str = "1" }); // matches with lstConstant
        lst.Add(new SampleExpression { str = "2" }); // matches with lstConstant
        lst.Add(new SampleExpression { str = "5" });
        var items = lst.Where(x => lstConstant.Contains(x.str)).ToList();
