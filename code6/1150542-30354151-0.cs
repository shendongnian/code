    public void EditA(A ThisIsA, B ThisIsB)
    {
        using (var Context = new LDZ_DEVEntities())
        {
            var _a = Context.As.Find(ThisIsA.AId);
            //var _b = Context.Bs.FirstOrDefault(_x => _x.BId == ThisIsB.BId);
            var _b = Context.Bs.Find(ThisIsB.BId);
            if (_b != null)
                Context.Bs.Attach(_b);
            else
                _b = ThisIsB;
            if (_b.C != null)
                Context.Cs.Attach(_b.C);
            _a.Bs.Add(_b);
            Context.SaveChanges();
        }
    }
