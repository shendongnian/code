    public class AssemblyVersionSerializationBinder : DefaultSerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            var type = base.BindToType(assemblyName, typeName);
            if (type != null)
            {
                var name = new AssemblyName(assemblyName);
                // If assemblyName has a version specified and it does not match the version of the loaded assembly, raise an error.
                if (name.Version != null && name.Version != type.Assembly.GetName().Version)
                {
                    HandleAssemblyNameMismatch(type, assemblyName, typeName);
                }
            }
            return type;
        }
        private void HandleAssemblyNameMismatch(Type type, string assemblyName, string typeName)
        {
            string message = string.Format("Mismatch between expected assembly name \"{0}\" and loaded assembly name \"{1}\"", type.Assembly.FullName, assemblyName);
            Debug.WriteLine(message);
            throw new JsonSerializationException(message);
        }
    }
