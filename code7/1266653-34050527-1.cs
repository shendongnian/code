    public interface ITest
    {
        DateTime CreatedAt { get; set; }
    }
    public class Test : ITest
    {
        public string Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public Test()
        {
            CreatedAt = DateTime.Now;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mapMethod = typeof (Program).GetMethod("Map", BindingFlags.Static | BindingFlags.Public);
            foreach (var genericMapMethod in from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                             from type in assembly.DefinedTypes
                                             where typeof (ITest).IsAssignableFrom(type)
                                             select mapMethod.MakeGenericMethod(type))
            {
                genericMapMethod.Invoke(null, new object[0]);
            }
            var test = new Test {Guid = Guid.NewGuid().ToString()};
            Thread.Sleep(1);
            var test2 = new Test();
            Mapper.Map(test, test2);
            Console.WriteLine(test2.Guid);
            Console.WriteLine(test.Guid == test2.Guid);
            Console.WriteLine(test.CreatedAt == test2.CreatedAt);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
        public static void Map<T>() where T : ITest
        {
            Mapper.CreateMap<T, T>()
            .ForMember(x => x.CreatedAt, y => {
                y.UseDestinationValue();
                y.Ignore();
            });
        }
    }
