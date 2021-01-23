    var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomObjectSource, CustomObjectDest>();
                c.CreateMap<Source, Destination>()
                  .AfterMap((Src, Dest) => Dest.NestedProp = new CustomObjectDest
                  {
                      Key = Src.NestedProp.Key,
                      Value = Src.NestedProp.Value
                  });
            });
            var mapper = config.CreateMapper();
            var MySourceList = new List<Source>
            {
                new Source
                {
                    Prop1 = "prop1",
                    NestedProp = new CustomObjectSource()
                    {
                        Key = "key",
                        Value = "val"
                    }
                }
            };
            var destinations = mapper.Map<List<Source>, List<Destination>>(MySourceList.ToList());
