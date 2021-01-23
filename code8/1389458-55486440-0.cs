    static ScriptMain()
            {
                AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            }
            static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            {
                //(string)Dts.Variables["User::CustomDLL"].Value;
                if (args.Name.Contains("HtmlAgilityPack"))
                {
                    string path = @"C:\Temp\";
                    return System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(path, "HtmlAgilityPack.dll"));
                    //return System.Reflection.Assembly.UnsafeLoadFrom(System.IO.Path.Combine(path, "HtmlAgilityPack.dll"));
                }
                return null;
            }
