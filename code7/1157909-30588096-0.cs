    public static void DisplayReferences() {
         Assembly assembly = Assembly.Load( ... );
         DisplayReferences( 0, assembly.GetName() );
    }
    private static void DisplayReferences(Int32 indent, AssemblyName name) {
        
        Assembly assembly = Assembly.Load( name )
        foreach(AssemblyName childname in assembly.GetReferencedAssemblies() ) {
            Console.WriteLine( "{0}{1}", "".PadLeft( indent ), childName.FullName );
            DisplayReferences( indent + 1, childName );
        }
    }
    
