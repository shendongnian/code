     List<Foo> SomeList = new List<Foo>();
            SomeList.Add(new Foo() {Bar=1,Baz ="ASDASD"}); 
            SomeList.Add(new Foo() {Bar=2,Baz ="dqwe"});
            SomeList.Add(new Foo() { Bar = 5, Baz = "fsdfsgsdg" });
            SomeList.Add(new Foo() { Bar = 5, Baz = "dghjhljkl" }); 
          foreach(Foo f in  SomeList.Where(x=>x.Bar==5).ToList())
          {
          // do some operations
          }
