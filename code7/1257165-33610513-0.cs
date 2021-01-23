    Soldier soldier = null;
    var list = session
        .QueryOver<Soldier>(() => soldier)
        .SelectList(l => l
            .Select(x => x.LastName).WithAlias(() => soldier.LastName)
            .Select(x => x.FirstName).WithAlias(() => soldier.FirstName)
        )
        .TransformUsing(Transformers.AliasToBean<Soldier>())
        // .Take(10) just 10
        .List<Soldier>();
    Assert.IsTrue(list.First().FirstName != null);
    Assert.IsTrue(list.First().LastName != null);
