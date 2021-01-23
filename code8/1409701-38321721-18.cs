    var result = ListCompare<Guid, Employee, Employee>(
        lt1,
        lt2,
        e => e.ID,
        (e1, e2) => new Employee
        {
            ID = e1.ID,
            Name = (e1.Name == e2.Name) ? "$" : (e2.Name + " (Modified)"),
            Age = (e1.Age == e2.Age) ? "$" : (e2.Age + " (Modified)"),
            Address = (e1.Address == e2.Address) ? "$" : (e2.Address + " (Modified)"),
            ContactNo = (e1.ContactNo == e2.ContactNo) ? "$" : (e2.ContactNo + " (Modified)")
         },
         e => new Employee
         {
              ID = l1.ID,
              Name = l1.Name + " (Added)",
              Age = l1.Age + " (Added)",
              Address = l1.Address + " (Added)",
              ContactNo = l1.ContactNo + " (Added)"
          },
          e => new Employee
          {
              ID = l1.ID,
              Name = " Deleted",
              Age = " Deleted",
              Address = " Deleted",
              ContactNo = " Deleted"
          });
