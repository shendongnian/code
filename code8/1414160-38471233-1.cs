    var foundvessel = context.tbl_vessels.Where(x => x.vessel_idx == model.vessel_idx).FirstOrDefault();
    var foundvspec = context.tbl_vessel_spec.Where(x => x.spec_idx == model.spec_idx).FirstOrDefault();
    if (foundvessel != null && foundvspec != null)
    {
        var vessel = new tbl_vessels
        {
            vessel_idx = model.vessel_idx,
            vessel_name = model.vessel_name
        };
        var vessel_spec = new tbl_vessel_spec
        {
            spec_idx = model.spec_idx,
            bhp = model.bhp
        }
    
        using (var context = new dataEntities())
        {
            this.TryUpdateModel(vessel);
            this.TryUpdateModel(vessel_spec);                               
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
