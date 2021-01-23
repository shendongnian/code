    var result = ListCompare<int, Employee, Employee>(
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
              ID = e.ID,
              Name = e.Name + " (Added)",
              Age = e.Age + " (Added)",
              Address = e.Address + " (Added)",
              ContactNo = e.ContactNo + " (Added)"
          },
          e => new Employee
          {
              ID = e.ID,
              Name = " Deleted",
              Age = " Deleted",
              Address = " Deleted",
              ContactNo = " Deleted"
          });
