     AutoMapper.Mapper.CreateMap<Foo, FooDto>()
                .AfterMap((src, dest) =>
                {
                    dest.Total = 8;//service call here
                    for (var i = 0; i < dest.Bars.Count; i++)
                    {
                        dest.Bars.ElementAt(i).Total = 9;//service call with src.Bars.ElementAt(i)
                    }
                });
    AutoMapper.Mapper.CreateMap<Bar, BarDto>();
    var t = AutoMapper.Mapper.Map<FooDto>(new Foo
            {
                Bars = new List<Bar> { new Bar { } }
            });
