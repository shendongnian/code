    public class testmodel
        {
            public string a {get;set;}
            public double b {get;set;}
        }
    testmodel[] list = {new testmodel{a="1",b=1}, new testmodel{a="22",b=2}, new testmodel{a="333",b=3}, new testmodel{a="4444",b=4}, new testmodel{a="55555", b=5}}
    var averageEvaluator = new System.Func<IEnumerable<testmodel>, IEnumerable<testmodel>>((pos) =>                         {
       var avg = pos.Average(x=>x.b);
       return pos.Where(x=>x.b < avg ).ToArray();
    })
    var results = averageEvaluator(list)
    foreach(var x in results){ print(x.a);}
