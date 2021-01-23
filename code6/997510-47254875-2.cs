        using System.Reflection;
        using System.IO;
        
        namespace MyLibrary
        {
            public class MyClass
            {
                public static string ReadFoo()
                {
                    var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    var filePath = buildDir + @"\foo.txt";
                    return File.ReadAllText(filePath);
                }
            }
        }
