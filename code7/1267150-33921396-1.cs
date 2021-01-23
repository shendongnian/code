    internal static List<Foo> OnlyWithQuxs(this List<Foo> model)
    {
        var foosToRemove = new List<Foo>();
    
        foreach (var foo in model)
        {
            var barsToRemove = new List<Bar>();
    
            foreach (var bar in foo.bars)
            {
                var bazWithQux = new List<Baz>();
                var bazsToRemove = new List<Baz>();
    
                foreach (var baz in bar.bazs)
                {
                    
                    baz.Quxs = GetbazQuxs(baz.Id)
                        .Where(qux => qux.Property == someValue)
                        .ToList();
                    bazWithQux.Add(baz);
                    if (baz.Quxs == null || baz.Quxs.Count() == 0)
                        bazsToRemove.Add(baz);
                }
    
                bar.bazs = bazWithQux.Except(bazsToRemove).ToList();
    
                if (bar.bazs == null || bar.bazs.Count() == 0)
                    barsToRemove.Add(bar);
            }
            foo.bars = foo.bars.Except(barsToRemove).ToList();
            if (foo.bars == null || foo.bars.Count() == 0)
                foosToRemove.Add(foo);
        }
        return model.Except(foosToRemove).ToList();
    }
