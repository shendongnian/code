    var _dc = (IObjectContextAdapter)db;
    var _oc = _dc.ObjectContext;
    var key;// = payroll_company.Key;
    ObjectStateEntry ose;
    if (_oc.ObjectStateManager.TryGetObjectStateEntry(key, out ose))
    {
        var _entity = (payroll_Company)ose.Entity;
        db.Entry(_entity).State = EntityState.Detached;
    }
    db.payroll_Company.Attach(payroll_company);
    db.Entry(payroll_company).State = EntityState.Modified;
