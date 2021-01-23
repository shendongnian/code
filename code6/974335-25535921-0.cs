    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Roslyn.Compilers;
    using Roslyn.Compilers.CSharp;
    using Roslyn.Scripting;
    using Roslyn.Scripting.CSharp;
    
    namespace testRoslyn
    {
        class Program
        {        
    
            static void Main(string[] args)
            {
                TestRoslyn tr = new TestRoslyn();
                tr.Test = "this was set from main program ";
                tr.test();
                System.Console.WriteLine(tr.Test);
                Console.ReadKey();
            }
        }
    
        public class TestRoslyn
        {
            public string Test;
    
            public TestRoslyn()
            {
            }
            
            public string test()
            {
                ScriptEngine roslynEngine = new ScriptEngine();
                Roslyn.Scripting.Session session = roslynEngine.CreateSession(this);
                session.AddReference(this.GetType().Assembly);
                session.AddReference("System.Web");
                session.ImportNamespace("System");
                session.ImportNamespace("System.Web");
                var result = (string)session.Execute("Test = Test + \" ... and this was set from roslyn code.\";Test");            
                return result;
            }
        }
                
    }
