    var NewCompany = new Company() {
          Areas = new List<Area>(){
            Areaid = 0
            Items = new List<Item>(){
               new Item(1),
               new Item(2)
               ...
               ...
            }
       }
    }
    
    //just add newCompany instance to the entity collection rest should be automatically taken care.
    _context.Company.Add(NewCompany);
    //no need to write below statement.
    //_context.Areas.AddRange(NewCompany.Areas);
