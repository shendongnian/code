            [Serializable]
        public class YourClass : SerializationBinder 
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                Type tyType = null;
                string sShortAssemblyName = assemblyName.Split(',')[0];
                Assembly[] ayAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly ayAssembly in ayAssemblies)
                {
                    if (sShortAssemblyName == ayAssembly.FullName.Split(',')[0])
                    {
                        tyType = ayAssembly.GetType(typeName);
                        break;
                    }
                }
                return tyType;
            }
            ...
