    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    namespace LibraryA
    {
        public static class Initializer
        {
            public static void Init()
            {
                AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
                {
                    if (!args.Name.StartsWith("LibraryB"))
                        return null;
                    return Assembly.Load(LibraryA.Properties.Resources.LibraryB);
                }; 
            }
        }
    }
