    public void EditA(A ThisIsA, B ThisIsB)
    {
        using (var Context = new LDZ_DEVEntities())
        {
            //if A has been loaded from context
            //dont attach it
            //if it has been created outside of the context
            //Context.Entry(ThisIsA).State = EntityState.Modified;
            var _b = Context.Bs.Find(ThisIsB.BId);
            if (_b == null)
            { 
                _b = ThisIsB;
            }
                
            ThisIsA.Bs.Add(_b);
            Context.SaveChanges();
        }
    }
