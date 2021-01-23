    public void EditA(A ThisIsA, B ThisIsB)
    {
        using (var Context = new LDZ_DEVEntities())
        {
            var a = Context.As.Find(ThisIsA.AId);
            //var b = Context.Bs.FirstOrDefault(x => x.BId == ThisIsB.BId);
            var b = Context.Bs.Find(ThisIsB.BId);
            if (b != null)
                Context.Bs.Attach(b);
            else
                b = ThisIsB;
            if (b.C != null)
                Context.Cs.Attach(b.C);
            a.Bs.Add(b);
            Context.SaveChanges();
        }
    }
