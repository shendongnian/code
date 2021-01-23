    using System;
    using AutoMapper;
    
    namespace TestAutoMapper
    {
        class Program
        {
            static void Main(string[] args)
            {
                var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDto>()
                    .ForMember(dest => dest.VehicleType, src => src.Ignore())); //and how to ignore properties
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
        }
    
        public class Car
        {
            public AutoType VehicleType { get; set; }
            public string EngineName { get; set; }
        }
    
        public class CarDto
        {
            public string VehicleType { get; set; }
            public string EngineName { get; set; }
        }
    
        public class AutoType
        {
            public string Name { get; set; }
            public string Code { get; set; }
        }
    }
