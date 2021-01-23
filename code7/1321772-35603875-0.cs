    internal class RouteToDtoConverter : TypeConverter<Route, DtoRoute>
    {
        protected override DtoRoute ConvertCore(Route source)
        {
            return new DtoRoute
            {
                Id = source.Id,
                GoogleRoute = JsonConvert.DeserializeObject<DtoGoogleRoute>(source.SerializedGoogleRoute)
            };
        }
    }
    internal class DtoToRouteConverter : TypeConverter<DtoRoute, Route>
    {
        protected override Route ConvertCore(DtoRoute source)
        {
            return new Route
            {
                Id = source.Id,
                SerializedGoogleRoute = JsonConvert.SerializeObject(source.GoogleRoute)
            };
        }
    }
    
    public class Route
    {
        public string Id { get; set; }
        public string SerializedGoogleRoute { get; set; }
    }
    public class DtoRoute
    {
        public string Id { get; set; }
        public DtoGoogleRoute GoogleRoute { get; set; }
    }
    public class DtoGoogleRoute
    {
        public int MyProperty { get; set; }
        public int MyProperty2 { get; set; }
    }
    
    AutoMapper.Mapper.CreateMap<Route, DtoRoute>()
                .ConvertUsing(new RouteToDtoConverter());
    AutoMapper.Mapper.CreateMap<DtoRoute, Route>()
                .ConvertUsing(new DtoToRouteConverter());
    var res = Mapper.Map<DtoRoute>(new Route
            {
                Id = "101",
                SerializedGoogleRoute = "{'MyProperty':'90','MyProperty2':'09'}"
            });
    var org = Mapper.Map<Route>(res);  //pass
