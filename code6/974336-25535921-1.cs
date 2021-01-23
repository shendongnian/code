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
                Eval.eval<TestRoslyn>("Test = Test + \" AND THIS WAS SET FROM Eval()\";", tr);           
                System.Console.WriteLine(tr.Test);
                string a = Eval.evalRet<TestRoslyn, string>("string a = \"return this from eval\";a");
                System.Console.WriteLine(a);
                tr.Test = "now return this";
                string b = Eval.evalRet<TestRoslyn, string>("string a = Test + \" ... and this\";a", tr);
                System.Console.WriteLine(b);
                double d = Eval.evalRet<TestRoslyn, double>("double dbl = 1.2345*3;dbl");
                System.Console.WriteLine(d);
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
    
        public static class Eval
        {
            public static void eval<T>(string strEval, T hostObject = null) where T : class
            {            
                ScriptEngine roslynEngine = new ScriptEngine();
                Roslyn.Scripting.Session session = roslynEngine.CreateSession(hostObject);
                if (hostObject != null)
                    session.AddReference(hostObject.GetType().Assembly);
                session.AddReference("System.Web");
                session.ImportNamespace("System");
                session.ImportNamespace("System.Web");
                session.Execute(strEval);
            }
    
            public static T2 evalRet<T, T2>(string strEval, T hostObject = null) where T : class
            {
                ScriptEngine roslynEngine = new ScriptEngine();
                Roslyn.Scripting.Session session = roslynEngine.CreateSession(hostObject);
                if (hostObject != null)
                    session.AddReference(hostObject.GetType().Assembly);
                session.AddReference("System.Web");
                session.ImportNamespace("System");
                session.ImportNamespace("System.Web");
                return (T2) session.Execute(strEval);            
            }
        }
    }
