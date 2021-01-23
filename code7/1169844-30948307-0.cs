    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    namespace StackOverflow
    {
        public static class Program
        {
            static void Main(string[] args)
            {
                RunExternalFunctionThread t = new RunExternalFunctionThread(File.ReadAllBytes(@"program.txt"));
                t.Run();
            }
            private class RunExternalFunctionThread
            {
                private Byte[] code;
                public RunExternalFunctionThread(Byte[] code)
                {
                    this.code = code;
                }
                public void Run()
                {
                    Thread t = new Thread(new ThreadStart(this.RunImpl));
                    t.IsBackground = false;
                    t.Priority = ThreadPriority.Normal;
                    t.SetApartmentState(ApartmentState.STA);
                    t.Start();
                }
                private void RunImpl()
                {
                    Assembly asm = Assembly.Load(this.code);
                    if (asm.EntryPoint == null) throw new ApplicationException("No entry point found!");
                    MethodInfo ePoint = asm.EntryPoint;
                    ePoint.Invoke(null, null);
                }
            }
        }
    }
