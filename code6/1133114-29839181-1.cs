    [Test]
    public void FutureTest()
    {
        using (ISession session = _sessionFactory.OpenSession())
        {
            var tx = session.BeginTransaction();
            for (int i = 0; i < 5; i++)
            {
                var fb = new FooBar() {FooBarName = "FooBar_" + i};
                session.Save(fb);
                var bz = new Baz() { BazName = "Baz_" + i};
                session.Save(bz);
                var b = new Bar() { BarName = "Bar_" + i ,FooBar = fb};
                session.Save(b);
                var f = new Foo() { FooName = "Foo_" + i , Bar = b,Baz = bz};
                session.Save(f);
            }
            session.Flush();
            tx.Commit();
        }
        using (ISession session = _sessionFactory.OpenSession())
        {
            Foo fooAlias = null;
            Bar barAlias = null;
            Baz bazAlias = null;
            FooBar fooBarAlias = null;
            var tx = session.BeginTransaction();
            var fooList = session.QueryOver<Foo>(() => fooAlias)
                .JoinAlias(f => f.Bar, () => barAlias)
                .JoinAlias(f => f.Baz, () => bazAlias)
                .JoinAlias(f => f.Bar.FooBar, () => fooBarAlias)
                .Future<Foo>().Distinct().ToList();
            foreach (var foo in fooList)
            {
                Console.WriteLine(foo.FooName);
                Console.WriteLine(foo.Bar.BarName);
                Console.WriteLine(foo.Baz.BazName);
                Console.WriteLine(foo.Bar.FooBar.FooBarName);
            }
            session.Flush();
            tx.Commit();
        }
    }
