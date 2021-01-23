    using System;
    using AutoMapper;
    
    namespace TestAutoMapper
    {
        class Program
        {
            static void Main(string[] args)
            {
                var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDto>()
                    .ForAllMembers(opt => opt.Condition(IsValidType))); //and how to conditionally ignore properties
                var car = new Car
                {
                    VehicleType = new AutoType
                    {
                        Code = "001DXT",
                        Name = "001 DTX"
                    },
                    EngineName = "RoadWarrior"
                };
    
                IMapper mapper = mapperConfiguration.CreateMapper();
                var carDto = mapper.Map<Car, CarDto>(car);
                Console.WriteLine(carDto.EngineName);
    
                Console.ReadKey();
            }
    
            private static bool IsValidType(ResolutionContext arg)
            {
                var isSameType = arg.SourceType== arg.DestinationType; //is source and destination type is same?
                return isSameType;
            }
        }
    
        public class Car
        {
            public AutoType VehicleType { get; set; } //same property name with different type
            public string EngineName { get; set; }
        }
    
        public class CarDto
        {
            public string VehicleType { get; set; } //same property name with different type
            public string EngineName { get; set; }
        }
    
        public class AutoType
        {
            public string Name { get; set; }
            public string Code { get; set; }
        }
    }
