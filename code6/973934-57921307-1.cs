csharp
            var appDomain = AppDomain.CreateDomain("some domain");
            var assembly = appDomain.Load(someAssemblyBytes);
an `AssemblyResolve` event will be generated. This happens because the assembly is loaded into BOTH domains. First domain is the one you expect it to be - `appDomain` and the assembly resolver for that domain is not called. Second is your current app domain, because you try to access the assembly from it while it's not present there.
Therefore if you execute `appDomain.Load(someAssemblyName);` from domain other than `appDomain` the resolve event will be generated twice, each for each domain.
In such case, if you want to omit the AssemblyResolve attempt (which will fail or will load assembly also into main domain) you have to create proxy class that derives from `MarshalByRefObject` in assembly that will be visible at both domains and use this proxy one to contain proxied class. I.e.:
csharp
    internal class AssemblyVersionProxy : MarshalByRefObject
    {
        public Version GetVersion(byte[] assemblyBytes)
        {
            var assembly = Assembly.Load(assemblyBytes);
            var version = new AssemblyName(assembly.FullName).Version;
            return version;
        }
    }
and use it:
csharp
        public Version GetAssemblyVersion(byte[] assemblyBytes)
        {
            var appDomain = AppDomain.CreateDomain(Guid.NewGuid().ToString());
            try
            {
                var proxyType = typeof(AssemblyVersionProxy);
                var proxy = (AssemblyVersionProxy)appDomain.CreateInstanceAndUnwrap(
                    proxyType.Assembly.FullName, proxyType.FullName,
                    false, BindingFlags.CreateInstance, null,
                    new object[0], null, new object[0]
                );
                var version = proxy.GetVersion(assemblyBytes);
                return version;
            }
            finally
            {
                AppDomain.Unload(appDomain);
            }
        }
