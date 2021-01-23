    using System.Diagnostics;
    using Autofac;
    using AutoMapper;
    
    namespace Sandbox
    {
        public partial class App
        {
            public App()
            {
                var builder = new ContainerBuilder();
                builder.Register(
                    c => new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile(new TestProfile());
                    }))
                    .AsSelf()
                    .SingleInstance();
    
                builder.Register(
                    c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                    .As<IMapper>()
                    .InstancePerLifetimeScope();
    
                builder.RegisterType<MappingEngine>()
                    .As<IMappingEngine>();
    
                builder.RegisterType<Test>().AsSelf();
    
                var container = builder.Build();
                container.Resolve<Test>();
            }
        }
    
        public class TestProfile : Profile
        {
            protected override void Configure()
            {
                CreateMap<Source, Destination>();
            }
        }
    
        public class Test
        {
            public Test(IMapper mapper)
            {
                var source = new Source { Id = 3 };
                var destination = mapper.Map<Destination>(source);
                Debug.Print(destination.Id.ToString());
            }
        }
    
        public class Source
        {
            public int Id { get; set; }
        }
    
        public class Destination
        {
            public int Id { get; set; }
        }
    }
