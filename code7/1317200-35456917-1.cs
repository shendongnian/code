    public class TypesProvider : MarshalByRefObject
    {
        public string[] RetrieveTypes()
        {
            return Assembly.GetExecutingAssembly().GetTypes().Select(x => x.FullName).ToArray();
        }
        public string[] RetrieveTypesForAnotherAssembly(string assemblyFile)
        {
            return Assembly.LoadFile(assemblyFile).GetTypes().Select(x => x.FullName).ToArray();
        }
    }
