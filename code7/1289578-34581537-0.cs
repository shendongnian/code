    public class DefaultAssemblyBinder : DefaultSerializationBinder
    {
        public string DefaultAssemblyName { get; private set; }
        public string DefaultNamespaceName { get; private set; }
        public DefaultAssemblyBinder(string defaultAssemblyName, string defaultNamespaceName)
        {
            this.DefaultAssemblyName = defaultAssemblyName;
            this.DefaultNamespaceName = defaultNamespaceName;
        }
        public override Type BindToType(string assemblyName, string typeName)
        {
            if (!string.IsNullOrEmpty(DefaultAssemblyName))
            {
                if (string.IsNullOrEmpty(assemblyName))
                    assemblyName = DefaultAssemblyName;
            }
            if (!string.IsNullOrEmpty(DefaultNamespaceName))
            {
                if (typeName != null && !typeName.Contains("."))
                    typeName = DefaultNamespaceName + "." + typeName;
            }
            return base.BindToType(assemblyName, typeName);
        }
        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            base.BindToName(serializedType, out assemblyName, out typeName);
            if (!string.IsNullOrEmpty(DefaultAssemblyName) && assemblyName != null)
                if (assemblyName == DefaultAssemblyName)
                    assemblyName = null;
            if (!string.IsNullOrEmpty(DefaultNamespaceName) && typeName != null)
            {
                int index = typeName.LastIndexOf('.');
                if (index < 0)
                    throw new JsonSerializationException(string.Format("Type {0} does not exist in any namespace, but a default namespace {1} has been set", serializedType.FullName, DefaultNamespaceName));
                if (index == DefaultNamespaceName.Length && string.Compare(DefaultNamespaceName, 0, typeName, 0, index, StringComparison.Ordinal) == 0)
                    typeName = typeName.Substring(index + 1);
            }
        }
    }
