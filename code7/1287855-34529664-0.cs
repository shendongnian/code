    public List<DOlead> sortLead(DOuser user, string Item)
    {    
        var propertyInfo = typeof(DOlead).GetProperty(Item);    
        List<DOlead> ObjLead = new List<DOlead>();
        ObjLead = _Context.leads.Where(x => x.is_converted == false).OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();
        return ObjLead;
    }
