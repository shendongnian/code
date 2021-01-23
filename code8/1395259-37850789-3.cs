     private static string asmBase;
    //asmBase contains the folder where all your assemblies found.
            public static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            {
                //This handler is called only when the common language runtime tries to bind to the assembly and fails.
    
                //Retrieve the list of referenced assemblies in an array of AssemblyName.
                Assembly MyAssembly, objExecutingAssemblies;
                string strTempAssmbPath = "";
                objExecutingAssemblies = args.RequestingAssembly;
                AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();
    
                //Loop through the array of referenced assembly names.
                foreach (AssemblyName strAssmbName in arrReferencedAssmbNames)
                {
                    //Check for the assembly names that have raised the "AssemblyResolve" event.
                    if (strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) == args.Name.Substring(0, args.Name.IndexOf(",")))
                    {
                        //Build the path of the assembly from where it has to be loaded.                
                        strTempAssmbPath = asmBase + "\\" + args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll";
                        break;
                    }
    
                }
                //Load the assembly from the specified path.                    
                MyAssembly = Assembly.Load(File.ReadAllBytes(strTempAssmbPath));
    
                //Return the loaded assembly.
                return MyAssembly;
            }
