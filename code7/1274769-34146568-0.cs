    public void UpdateInspection (EditInspectonViewModel editedInspection)
    {
        //get the inspection we're editing
        Inspection inspection = _repo.GetAll<Inspection>().Single(x=>x.Id==editedInspection.Id;
        //set the values to what was passed in
        inspection.Name = editedInspection.Name;
        inspection.Description = editedInspection.Description;
        // Here is where I'm stuck (note-Damages is of type  DamageViewModel)
        var damages = editedInspection.Damages
                                      .Join(inspection.Damages, 
                                            d => d.Id, d => d.Id, 
                                            (vmDmg, dbDmg) => new { vmDmg, dbDmg });
        foreach (var damage in damages)
        {
            damage.dbDmg.Property = damage.vmDmg.Property;
        }
        _repo.SaveChanges();
    }   
