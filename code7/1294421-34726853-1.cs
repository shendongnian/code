    namespace ConsoleApplication
    {
        public class Program
        {
            static void Main()
            {
                //System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(DerivedEnum).TypeHandle);
    
                foreach (var value in DerivedEnum.AllKeys)
                {
                    Console.WriteLine(value);
                }
    
                Console.Read();
            }
        }
    
        public class BaseEnum
        {
            protected static readonly IDictionary<string, BaseEnum> Dictionary = new Dictionary<string, BaseEnum>();
    
            public static ICollection<string> AllKeys
            {
                get
                {
                    return Dictionary.Keys;
                }
            }
    
            public static readonly BaseEnum BaseValue1 = new BaseEnum("BaseValue1");
            public static readonly BaseEnum BaseValue2 = new BaseEnum("BaseValue2");
    
    
            protected BaseEnum(string value)
            {
                Dictionary[value] = this;
            }
        }
    
        public class DerivedEnum : BaseEnum
        {
            new public static ICollection<string> AllKeys
            {
                get
                {
                    return Dictionary.Keys;
                }
            }
    
            public static readonly DerivedEnum DerivedValue1 = new DerivedEnum("DerivedValue1");
            public static readonly DerivedEnum DerivedValue2 = new DerivedEnum("DerivedValue2");
    
    
            protected DerivedEnum(string value)
                : base(value)
            {
            }
        }
    }
