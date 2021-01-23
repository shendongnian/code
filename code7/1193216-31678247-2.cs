    people = Build<PersonModel>(getPeople);
    foreach (var person in people)
    {
         var m = person.ManufacturerIDs.Split(',')
             .Where(id => (manufacturers != null && manufacturers.Any(item => String.Compare(item.ManufacturerId.ToString(), id, true) == 0))).ToList();
        
         var r = person.ManufacturerIDs.Split(',')
              .Where(id => (repAgencies != null && repAgencies.Any(item => String.Compare(item.RepAgencyId.ToString(), id, true) == 0))).ToList();
        
         if (m.Any() || r.Any())
              filter.AddRange(people.Where(model => model.PersonId == person.PersonId).ToList());
    }
