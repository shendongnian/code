                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<SourceEmployee, DestinationEmployee>();
    
                    cfg.CreateMap<SourceEmployee, DestinationEmployee>()
                    .ForMember(f => f.FullName, f => f.MapFrom(a => string.Concat(a.FirstName, " ", a.LastName)))
                    .ForMember(
                        x => x.Address,
                        x => x.MapFrom(
                            y => y.EmployeeResidences.Select(
                                r => new ResidentialAddress1()
                                {
                                    FullAddress = String.Concat(
                                        r.State, "  ", r.City, "  ", r.ZipCode)
                                }).ToList()));
                });
    
                SourceEmployee emp = new SourceEmployee()
                {
                    EmployeeID = 1,
                    FirstName = "Alex",
                    LastName = "Green",
                    EmployeeResidences = new List<ResidentialAddress>()
                    {
                        new ResidentialAddress() { State = "abc", City = "def", ZipCode = 110 },
                        new ResidentialAddress() { State = "foo", City = "qwe", ZipCode = 220 },
                        new ResidentialAddress() { State = "bar", City = "ert", ZipCode = 330 },
                    }
                };
    
                var sourceEmp = Mapper.Map<SourceEmployee, DestinationEmployee>(emp);
                Console.WriteLine(sourceEmp.Address.Count);    
                Console.WriteLine(sourceEmp.Address[1].FullAddress);
