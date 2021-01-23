            class Program
            {
                static void Main(string[] args)
                {
                    OnlyOne.SetMyName("I m the only one."); //static constructor will be called first time when the class will be referenced.
                    Console.WriteLine(OnlyOne.GetMyName());
        
                    NoInstance.SetMyName("I have private constructor"); //No constructor will be called when the class will be referenced.
                    Console.WriteLine(NoInstance.GetMyName());
        
                    Console.Read();
                }
            }
        
            static class OnlyOne
            {
                static string name;
                /// <summary>
                /// This will be called first time when even the class will be referenced.
                /// </summary>
                static OnlyOne()
                {
                    name = string.Empty;
                    Console.WriteLine("Static constructor is called");
                }
        
                public static string GetMyName()
                {
                    return name;
                }
        
                public static void SetMyName(string newName)
                {
                    name = newName;
                }
            }
        
            public class NoInstance
            {
                static string name;
                private NoInstance()
                {
                    name = string.Empty;
                    Console.WriteLine("No instance private constructor is called");
                }
        
                public static string GetMyName()
                {
                    return name;
                }
        
                public static void SetMyName(string newName)
                {
                    name = newName;
                }
            }
        }
