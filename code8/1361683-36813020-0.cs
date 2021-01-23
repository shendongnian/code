        public List<NameDTO> Get(string Name = "")
        {
            var nameList = (from o in db.People.AsEnumerable()
                            where o.nameTrim().ToLower() == NameTrim().ToLower()
                            join s in db.Employee on
                             o.empID equals s.empID
                            select new
                            {
                                s.empID,
                                o.Id
                            }).ToList();
        }
        //use this if you want similar records from database
        public IEnumerable<NameDTO> Get(string Name = "")
        {
            var nameList = (from o in db.People.AsEnumerable()
                            where o.nameTrim().ToLower().Contains(NameTrim().ToLower())
                            join s in db.Employee on
                             o.empID equals s.empID
                            select new
                            {
                                s.empID,
                                o.Id
                            }).ToList();
        }
    }
