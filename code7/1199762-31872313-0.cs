    class testPython
    {
        public void runScript() {
            String path = @"c:\pythonSpeedTest.py";
            var source = System.IO.File.ReadAllText(path);           
            Microsoft.Scripting.Hosting.ScriptEngine py = Python.CreateEngine();
            Microsoft.Scripting.Hosting.ScriptScope scope = py.CreateScope();
            var paths = py.GetSearchPaths();
            paths.Add(@"c:\Program Files (x86)\IronPython 2.7\Lib");
            py.SetSearchPaths(paths);
            try { 
                py.Execute(source);
            }catch (Exception ex){
                Console.WriteLine("Error occured in python script\n"+ex);
                Console.ReadKey();
                return;
            }
        }
    }
