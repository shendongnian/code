    public static class AssemblyResolver
    {
        internal static void Hook(params string[] folders)
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
                {
                    // Check if the requested assembly is part of the loaded assemblies
                    var loadedAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
                    if (loadedAssembly != null)
                        return loadedAssembly;
                    // This resolver is called when an loaded control tries to load a generated XmlSerializer - We need to discard it.
                    // http://connect.microsoft.com/VisualStudio/feedback/details/88566/bindingfailure-an-assembly-failed-to-load-while-using-xmlserialization
                    var n = new AssemblyName(args.Name);
                    if (n.Name.EndsWith(".xmlserializers", StringComparison.OrdinalIgnoreCase))
                        return null;
                    // http://stackoverflow.com/questions/4368201/appdomain-currentdomain-assemblyresolve-asking-for-a-appname-resources-assembl
                    if (n.Name.EndsWith(".resources", StringComparison.OrdinalIgnoreCase))
                        return null;
                    string assy = null;
                    // Find the corresponding assembly file
                    foreach (var dir in folders)
                    {
                        assy = new[] { "*.dll", "*.exe" }.SelectMany(g => Directory.EnumerateFiles(dir, g)).FirstOrDefault(f =>
                                   {
                                       try { return n.Name.Equals(AssemblyName.GetAssemblyName(f).Name, StringComparison.OrdinalIgnoreCase); }
                                       catch (BadImageFormatException) { return false; /* Bypass assembly is not a .net exe */ }
                                       catch (Exception ex) { throw new ApplicationException("Error loading assembly " + f, ex); }
                                   });
                        if (assy != null)
                            return Assembly.LoadFrom(assy);
                    }
                    throw new ApplicationException("Assembly " + args.Name + " not found");
                };
        }
    }
