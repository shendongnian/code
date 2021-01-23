    using System;
    using System.Collections.Generic;
    using AutoMapper;
    
    namespace ConsoleApplication
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var sourceObjects = new SourceObject[] {
                    new SourceObject{Property1 = "prop 1A"},
                    new SourceObject{Property2 = "Prop 2B"},
                    new SourceObject{Property3 = "Prop 3C"}};
    
                var someFlag = true;
                var anotherFlag = false;
    
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<SourceObject, DestinationObject>().ConvertUsing<CustomConverter>();
                });
    
                var vm = new ViewModel
                {
                    Objects = Mapper.Map<IList<SourceObject>, IEnumerable<DestinationObject>>(sourceObjects, opts =>
                    {
                        opts.Items.Add("AnotherDependency", new AnotherDependency { Foo = "bar" });
                        opts.Items.Add("flag1", someFlag);
                        opts.Items.Add("flag2", anotherFlag);
                    })
                };
    
                foreach (var obj in vm.Objects)
                {
                    Console.WriteLine($"[{obj.Property1}, {obj.Property2}, {obj.Property3}, {obj.Property4}, {obj.Property5}, {obj.Property6}]");
                }
            }
        }
    
        public class CustomConverter : ITypeConverter<SourceObject, DestinationObject>
        {
            public DestinationObject Convert(ResolutionContext context)
            {
                return Convert(context.SourceValue as SourceObject, context);
            }
    
            public DestinationObject Convert(SourceObject source, ResolutionContext context)
            {
                var dest = new DestinationObject
                {
                    Property1 = source?.Property1,
                    Property2 = source?.Property2,
                    Property3 = source?.Property3
                };
    
                var items = context.Options.Items;
    
                Utility.SetupProperties(dest,
                    items["AnotherDependency"] as AnotherDependency,
                    dest.Property3,
                    items["flag1"] as bool? ?? false,
                    items["flag2"] as bool? ?? false);
    
                return dest;
            }
        }
    
        public static class Utility
        {
            public static void SetupProperties(DestinationObject x, AnotherDependency ad, string a, bool b, bool c)
            {
                x.Property4 = ad.Foo;
                if (b || c)
                {
                    x.Property5 = ad?.ToString() ?? a;
                }
                if (b && c)
                {
                    x.Property6 = ad?.ToString() ?? a;
                }
                return;
            }
        }
        public class ViewModel
        {
            public IEnumerable<DestinationObject> Objects { get; set; }
        }
        public class AnotherDependency { public string Foo { get; set; } }
        public class SourceObject
        {
            public string Property1 { get; set; }
            public string Property2 { get; set; }
            public string Property3 { get; set; }
        }
        public class DestinationObject
        {
            public string Property1 { get; set; }
            public string Property2 { get; set; }
            public string Property3 { get; set; }
            public string Property4 { get; set; }
            public string Property5 { get; set; }
            public string Property6 { get; set; }
        }
    }
