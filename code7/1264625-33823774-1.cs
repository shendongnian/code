            Assembly myAssembly = Assembly.GetExecutingAssembly();
            foreach (AssemblyName lRefAsm in myAssembly.GetReferencedAssemblies())
            {
                Assembly ass = Assembly.Load(lRefAsm.FullName);
                string codeBase = ass.CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                Console.WriteLine(Path.GetDirectoryName(path));
            }
