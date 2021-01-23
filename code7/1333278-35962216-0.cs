    public class ProcessRunner : MarshalByRefObject
    {
        public void Run()
        {
            Type typ = null;
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type t = asm.GetType("LSCT.ScriptClass");
                if (t != null)
                {
                    typ = t;
                    break;
                }
            }
            MethodInfo info = typ.GetMethod("DefineX");
            var func = (Func<double>)Delegate.CreateDelegate(typeof(Func<double>), info);
            double x = func();
            Console.WriteLine("Output was : " + x);
        }
    }
