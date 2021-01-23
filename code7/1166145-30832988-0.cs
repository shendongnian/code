    var Fisks=new[]{
        new {Havn=new{Id=1},Date=DateTime.MinValue,Arter=new{Name="A"},Sort=1,Title="A1"},
        new {Havn=new{Id=1},Date=DateTime.MinValue.AddDays(1),Arter=new{Name="A"},Sort=1,Title="A2"},
        new {Havn=new{Id=1},Date=DateTime.MinValue,Arter=new{Name="B"},Sort=1,Title="B1",},
        new {Havn=new{Id=1},Date=DateTime.MinValue.AddDays(2),Arter=new{Name="B"},Sort=1,Title="B2",},
        new {Havn=new{Id=1},Date=DateTime.MinValue.AddDays(2),Arter=new{Name="B"},Sort=1,Title="B3",},
    };
    var stopwatch=Stopwatch.StartNew();
    var one = Fisks.Where(s=>s.Havn.Id == 1).OrderByDescending(s=>s.Date);
    var two = one.GroupBy(s=>new {s.Arter.Name, s.Sort});
    var three = two.Select(s=>s.FirstOrDefault());
    var answer=three.ToArray();
    stopwatch.Stop();
    stopwatch.ElapsedTicks.Dump("elapsed Ticks");
    answer.Dump();
    stopwatch.Restart();
    answer=Fisks
    .Where(f=>f.Havn.Id.Equals(1))
    .GroupBy(s=>new {s.Arter.Name, s.Sort},(k,g)=>new{
        s=g.OrderByDescending(s=>s.Date).First()
    })
    .Select(g=>g.s)
    .ToArray();
    stopwatch.Stop();
    stopwatch.ElapsedTicks.Dump("elapsed Ticks");
