    internal class CustomConverter : TypeConverter<List<Source>, List<Destination>>
    {
        protected override List<Destination> ConvertCore(List<Source> source)
        {
            if (source == null) return null;
            if (!source.Any()) return null;
            var output = new List<Destination>();
            output.AddRange(source.Select(a => new Destination
            {
                Property1 = (string)a.Attributes["Property1"],
                Property2 = (string)a.Attributes["Property2"],
                Json = JsonConvert.SerializeObject(a.ObjectWeWantAsJson)
            }));
            return output;
        }
    }
    var source = new List<Source>
            {
                new Source{
                    Attributes = new Dictionary<string,object>{
                        {"Property1","Property1-Value"},
                        {"Property2","Property2-Value"}
                    },
                    ObjectWeWantAsJson = new ComplexObject{Name = "Test", Age = 27}
                }
            };
    Mapper.CreateMap<List<Source>, List<Destination>>().
                ConvertUsing(new CustomConverter());
    var dest = Mapper.Map<List<Destination>>(source);
