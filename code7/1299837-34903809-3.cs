    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1 {
        class Program {
            static void Main(string[] args) {
                TemplateParser parser = new TemplateParser("C:\\myTextFile.txt");
                parser.Tags.Add("obj", 1);
                parser.Tags.Add("Test", new Test { Id = 1, Title = "This is a text" });
    
                parser.Parse();
                foreach (string line in parser.ToArray()) {
                    Console.WriteLine(line);
                }
            }
        }
    
        class Test {
            public int Id { get; set; }
            public string Title { get; set; }
        }
    }
