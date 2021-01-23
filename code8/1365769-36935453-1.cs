    public class Proxy : MarshalByRefObject
    {
        public void Run()
        {
            var assembly = AppDomain.CurrentDomain.Load(File.ReadAllBytes(@"C:\Users\Mkrtich_Mazmanyan\Downloads\ExBinder\Exbinder\bin\Debug\InvokeHelper.dll"));
    
            Type[] mytypes = assembly.GetTypes();
            BindingFlags flags = (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            foreach (Type t in mytypes)
            {
                MethodInfo[] mi = t.GetMethods(flags); // you can change this flag , commented some flags :) view only plublic or bla bla elshan
                Object obj = Activator.CreateInstance(t);
                foreach (MethodInfo m in mi)
                {
                    if (m.Name.Equals("PrintHello")) m.Invoke(obj, null); //my func name :) you can set this via config :D
                }
            }
        }
    }
