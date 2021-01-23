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
                tr.Test = "this was set from main program for eval";
                Eval e = new Eval();
                e.create<TestRoslyn>(tr);                           
                e.eval("Test = Test + \" AND THIS WAS SET FROM Eval()\";");
                System.Console.WriteLine(tr.Test);
                string a = e.eval<string>("string a = \"return this from eval\";a");
                System.Console.WriteLine(a);
                tr.Test = "now return this";
                string b = e.eval<string>("string a = Test + \" ... and this\";a");
                System.Console.WriteLine(b);
                double d = e.eval<double>("double dbl = 1.2345*3;dbl");
                System.Console.WriteLine(d);
                e.eval("string testIt(string a){return \"testIt(): \"+a+\"\";}");
                string c = e.eval<string>("string c = testIt(\"nice\");c");
                System.Console.WriteLine(c);
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
    
        public class Eval
        {
            ScriptEngine RoslynEngine = new ScriptEngine();
            Roslyn.Scripting.Session Session;
    
            public void create<T>(T hostObject = null) where T : class
            {
                RoslynEngine = new ScriptEngine();
                Session = RoslynEngine.CreateSession(hostObject);
                if (hostObject != null)
                    Session.AddReference(hostObject.GetType().Assembly);
                Session.AddReference("System.Web");
                Session.ImportNamespace("System");
                Session.ImportNamespace("System.Web");
            }
    
            public void eval (string strEval)
            {                                                
                Session.Execute(strEval);
            }
    
            public T eval<T>(string strEval) 
            {
                return (T) Session.Execute(strEval);            
            }
        }
    }
