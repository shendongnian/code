        var branchList = from b in Branches select new MyClass { Number = b.Number, Name =   b.Name };
                 List<MyClass> listBranchToAdd = new List<MyClass>();
              foreach (var a in branchList)
               {
            
                 listBranchToAdd.Add(a);
               }
    Branches.Store.DataSource = listBranchToAdd;
      Branches.Store.DataBind();
            MyClass{
            public string Name {get;set;}
            public int Number {get ;set;}
            }
