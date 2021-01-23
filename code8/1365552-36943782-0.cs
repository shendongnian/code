    from bh in db.BillingHiBHory
    join wa in db.WorkingAccount
    on new { bh.UniversalAccountId, bh.BillingRegion }
    equals new { wa.UniversalAccountId, wa.BillingRegion }
    into bh_wa from wa in bh_wa.DefaultIfEmpty() // this turns the above (inner) join into left outer join
    join ba in db.BillingAccount
    on new { bh.UniversalAccountId, bh.BillingRegion }
    equals new { ba.UniversalAccountId, ba.BillingRegion }
    into bh_ba from ba in bh_ba.DefaultIfEmpty()
    join bad in db.BillingAddress
    on new { bh.Grouping, bh.SubGrouping, bh.BillingRegion }
    equals new { bad.Grouping, bad.SubGrouping, bad.BillingRegion }
    into bh_bad from bad in bh_bad.DefaultIfEmpty()
    join si in db.SubscriberInfo
    on new { bh.Grouping, bh.SubGrouping, bh.BillingRegion }
    equals new { si.Grouping, si.SubGrouping, si.BillingRegion }
    into bh_si from si in bh_si.DefaultIfEmpty()
    join sad in db.ServiceAddress
    on new { si.ServceControlNum, si.BillingRegion }
    equals new { sad.ControlNumberAssigned, sad.BillingRegion }
    into si_sad from sad in si_sad.DefaultIfEmpty()
    join c in db.CRMSTG_CONTACT
    on new { bh.AccountNum, bh.BillingRegion }
    equals new { c.AccountNum, c.BillingRegion }
    into bh_c from c in bh_c.DefaultIfEmpty()
    where bh.Grouping == Grouping
       && bh.SubGrouping == SubGrouping
    // ... (the rest)
