      public static class MapperExtentions
      {
        public static TResult MergeInto<TResult>(this IMapper mapper, object item1, object item2)
        {
            return mapper.Map(item2, mapper.Map<TResult>(item1));
        }
        public static TResult MergeInto<TResult>(this IMapper mapper, params object[] objects)
        {
            var res = mapper.Map<TResult>(objects.First());
            return objects.Skip(1).Aggregate(res, (r, obj) => mapper.Map(obj, r));
        }
      }
       //How to use extentions
      var personList = new List<Person> { new Person { ID=1, Name="David Johnson", PhNo="(111) 111-1111"},
                                        new Person { ID=2, Name="Marvin Miller", PhNo="(222) 222-2222"},
                                        new Person { ID=3, Name="Jack Wilson", PhNo="(333) 333-3333"}};
      var companyList = new List<Company> { new Company { EmpNo= 1, PersonID = 1, Title="Director"},
                                    new Company { EmpNo= 2, PersonID = 2, Title="Surgeon"},
                                    new Company { EmpNo= 3, PersonID = 3, Title="Sales"}};
    var personMapConfig = new MapperConfiguration(c =>
        c.CreateMap<Person, PersonCompany>()
        .ForMember(x => x.Name, y => y.MapFrom(a => a.Name))
        .ForMember(x => x.PhNo, y => y.MapFrom(a => a.PhNo))
        .ForMember(x => x.ID, y => y.MapFrom(a => a.ID))
    );
    var companyMapConfig = new MapperConfiguration(c =>
        c.CreateMap<Company, PersonCompany>()
        .ForMember(d => d.EmpNo, opt => opt.MapFrom(s => s.EmpNo))
        .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
    );
    var model = personMapConfig.CreateMapper().Map<List<Person>, List<PersonCompany>>(personList);
    companyMapConfig.CreateMapper().Map<List<Company>, List<PersonCompany>>(companyList, model);
        var result = companyList.Join(personList, s => s.PersonID, t => t.ID, (c, p) => _mapper.MergeInto<PersonCompany>(c, p));
