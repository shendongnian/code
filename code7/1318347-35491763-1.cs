    using System;
    using System.IO;
    using System.Reflection;
    
    namespace BadApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("do bad");
    
                Assembly good = null;
    
                var ea = Assembly.GetExecutingAssembly();
                using (var rs = ea.GetManifestResourceStream(ea.GetManifestResourceNames()[0]))
                using (var ms = new MemoryStream())
                {
                    rs.CopyTo(ms);
                    good = Assembly.Load(ms.ToArray());
                }
    
                var ep = good.EntryPoint;
                ep.Invoke(null, new [] {args});
    
                Console.WriteLine("ha ha too late");
            }
        }
    }
