        // Use if you want same records  with name you provide
        public List<NameDTO> Get(string Name = "")
        {
            var nameList = (from o in db.People.AsEnumerable()
                            where o.name.Trim().ToLower() == Name.Trim().ToLower()
                            join s in db.Employee on
                             o.empID equals s.empID
                            select new NameDTO()
                            {
                              EmpId =  s.empID,
                               Id = o.Id
                            }).ToList();
        }
        //use this if you want similar records from database
        public IEnumerable<NameDTO> Get(string Name = "")
        {
            var nameList = (from o in db.People.AsEnumerable()
                            where o.name.Trim().ToLower().Contains(Name.Trim().ToLower())
                            join s in db.Employee on
                             o.empID equals s.empID
                           select new NameDTO()
                            {
                              EmpId =  s.empID,
                               Id = o.Id
                            }).ToList();
        }
    }
