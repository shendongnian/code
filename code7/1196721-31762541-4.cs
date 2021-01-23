    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    namespace AppDomain
    {
    [Serializable]
    class Program
    {
        static System.AppDomain assemblyDomain = null;
        static void Main(string[] args)
        {
            var inp = "go";
            while (inp.ToString().ToLower().Trim() != "stop")
            {
                start();
                inp = Console.ReadLine();
            }
        }
        private static void start()
        {
            //Check if appdomain and assembly is already loaded
            if (assemblyDomain != null)
            {
                //unload appDomain and hence the assembly
                System.AppDomain.Unload(assemblyDomain);
                //Code to download new dll
            }
            string cwd = System.AppDomain.CurrentDomain.BaseDirectory;
            string sourceFileName = @"C:\Users\deepak\Documents\visual studio 2010\Projects\ConsoleApplication1\ConsoleApplication2\bin\Debug\ConsoleApplication2.exe";
            string dllName = "ConsoleApplication2.exe";
            // copy the file
            if (File.Exists(cwd + dllName))
            {
                File.Delete(cwd + dllName);
            }
            File.Copy(sourceFileName, cwd + dllName);
            assemblyDomain = System.AppDomain.CreateDomain("assembly1Domain", null);
            assemblyDomain.DoCallBack(() =>
            {
                var t = Task.Factory.StartNew(() =>
                {
                    try
                    {
                        string sss = "";
                        string dllName1 = "ConsoleApplication2.exe";
                        Assembly assembly = Assembly.LoadFile(Directory.GetCurrentDirectory() + @"\" + dllName1);
                        Type type = assembly.GetType("Lecture_1___dotNetProgramExecution.Program");
                        MethodInfo minfo = type.GetMethod("Main", BindingFlags.Public | BindingFlags.NonPublic |
                                  BindingFlags.Static | BindingFlags.Instance);
                        minfo.Invoke(Activator.CreateInstance(type), null);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                });
            });
        }
    }
    }
    using System;
    using System.Text;
    using System.Threading;
    namespace Lecture_1___dotNetProgramExecution
    {
    [Serializable]
    class Program
    {
        static void Main()
        {
            while (true)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("log something new yippe ");
                // flush every 20 seconds as you do it
                //File.AppendAllText(@"C:\logs.txt", sb.ToString());
                Console.WriteLine(sb.ToString());
                sb.Clear();
                Thread.Sleep(3000);
            }
        }
    }
    }
