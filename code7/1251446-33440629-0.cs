    public class CustomNamespaceSerializationBinder : DefaultSerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            foreach (Assembly asm in PluginLoader.GetPluginAssemblies())
            {
                if (asm.FullName.Contains(assemblyName))
                {
                    assemblyName = asm.FullName;
                    break;
                }
            }
            return base.BindToType(assemblyName, typeName);
        }
    }
