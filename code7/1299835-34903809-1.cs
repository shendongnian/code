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
                parser.Tags.Add("textVariable", "this is a text");
            }
        }
    }
