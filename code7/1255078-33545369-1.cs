    internal class SavegameBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            // of course, use the assembly version of the old version here
            AssemblyName asmName = new AssemblyName(assemblyName);
            if (asmName.Version == new Version(1, 0, 0, 0) && typeName == typeof(Savegame).FullName)
                return typeof(SavegameNew);
            // otherwise we do not change the mapping
            return null;
        }
    }
