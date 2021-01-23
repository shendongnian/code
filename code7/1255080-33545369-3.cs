    internal class SavegameBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            // Of course, use the assembly version of the old version here.
            // You don't even need to change the assembly version, though than can lead to ambiguity
            AssemblyName asmName = new AssemblyName(assemblyName);
            if (asmName.Version == new Version(1, 0, 0, 0) && typeName == typeof(Savegame).FullName)
                return typeof(SavegameNew);
            // otherwise we do not change the mapping
            return null;
        }
    }
