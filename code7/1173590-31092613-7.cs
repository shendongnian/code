        var branchList = from b in Branches select new MyClass { Number = b.Number, Name =   b.Name };
        
    strcmb.DataSource = branchList.ToList();
      strcmb.DataBind();
            MyClass{
            public string Name {get;set;}
            public int Number {get ;set;}
            }
