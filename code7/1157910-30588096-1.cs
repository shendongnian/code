    public static void DisplayReferences() {
         Assembly assembly = Assembly.Load( ... );
         HashSet<String> seen = new HashSet<String>();
         DisplayReferences( 0, seen, assembly.GetName() );
    }
    private static void DisplayReferences(Int32 indent, HashSet<String> seen, AssemblyName name) {
        
        Assembly assembly = Assembly.Load( name )
        foreach(AssemblyName childName in assembly.GetReferencedAssemblies() ) {
            
            if( !seen.Contains( childName.FullName ) ) {
                
                seen.Add( childName.FullName );
                Console.WriteLine( "{0}{1}", "".PadLeft( indent ), childName.FullName );
                DisplayReferences( indent + 1, childName );
            }
           
        }
    }
    
