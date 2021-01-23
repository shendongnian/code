    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using IronPython.Hosting;
    using Microsoft.Scripting;
    using Microsoft.Scripting.Hosting;
    using IronPython.Runtime;
    
    namespace RunPython
    {
        class Program
        {
            static void Main(string[] args)
            {
                ScriptRuntimeSetup setup = Python.CreateRuntimeSetup(null);
                ScriptRuntime runtime = new ScriptRuntime(setup);
                ScriptEngine engine = Python.GetEngine(runtime);
                ScriptSource source = engine.CreateScriptSourceFromFile("HelloWorld.py");
                ScriptScope scope = engine.CreateScope();
                List<String> argv = new List<String>();
                //Do some stuff and fill argv
                argv.Add("foo");
                argv.Add("bar");
                engine.GetSysModule().SetVariable("argv", argv);
                source.Execute(scope);
            }
        }
    }
