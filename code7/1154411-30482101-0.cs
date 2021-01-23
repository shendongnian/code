        public class GenericProxyAttribute : ProxyAttribute
        {
            public override MarshalByRefObject CreateInstance(Type serverType)
            {
                string zTypeName = serverType.Name;
    
                try
                {
                    Assembly zLibrary = Assembly.LoadFrom(@"C:\Assemblies\Custom.dll");
                    Type zType = zLibrary.GetType(string.Format("Custom.{0}", zTypeName), false, true);
                    return base.CreateInstance(zType);
                }
                catch (Exception)
                {
                    return base.CreateInstance(serverType);
                }
            }
        }
        [GenericProxy]
        public class Document : ContextBoundObject
        {
            public virtual string GetObjectName() 
            {
                return "Generic Document"; 
            }
        }
