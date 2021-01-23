    public class Main
    {
        private AppDomain ad = null;
        private proxy remoteWorker = null;
        public INativeHandleContract LoadAssembly(string assemblyname, string fullInterfaceName)
        {
            if (ad != null)
            {
                AppDomain.Unload(ad);
            }
            var domSetup = new AppDomainSetup();
            domSetup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            domSetup.PrivateBinPath = AppDomain.CurrentDomain.BaseDirectory;
            domSetup.ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            domSetup.LoaderOptimization = LoaderOptimization.MultiDomainHost;
            var adevidence = AppDomain.CurrentDomain.Evidence;
            ad = AppDomain.CreateDomain(assemblyname, adevidence, domSetup);
            ad.AssemblyResolve += ad_AssemblyResolve;
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            remoteWorker = (proxy)ad.CreateInstanceAndUnwrap(typeof(proxy).Assembly.FullName, "INATO.UPINAIS.UCLibrary.proxy");
            return remoteWorker.GetControl(assemblyname, fullInterfaceName);
        }
        public void DoTheTrick()
        {
            var uControl = LoadAssembly("assemblyName", "interfaceName");
            panel.Content = FrameworkElementAdapters.ContractToViewAdapter(uControl);
            remoteWorker.RemoteInvoke("methodName", new object[] { });
        }
    }
    public class proxy : MarshalByRefObject
    {
        private object _currentInstance;
        public INativeHandleContract GetControl(string AssemblyName, string strFullNamespaceName)
        {
            var assembly = Assembly.LoadFrom(m_strAssemblyDirectory + AssemblyName);
            var type1 = typeof(IUPiAssemblyProcedure);
            var type2 = typeof(IUPiCardProcedure);
            var type3 = typeof(IUPiDatabaseFrame);
            var type4 = typeof(IUPiUserFrame);
            var t = from T in assembly.GetTypes() where type1.IsAssignableFrom(T) || type2.IsAssignableFrom(T) || type3.IsAssignableFrom(T) || type4.IsAssignableFrom(T) select T;
            if (t.Count<Type>() == 0) return null;
            var tName = t.First<Type>().FullName;
            _currentInstance = assembly.CreateInstance(tName);
            return FrameworkElementAdapters.ViewToContractAdapter((FrameworkElement)_currentInstance);
        }
        public void RemoteInvoke(string methodName, object[] parameters)
        {
            var type = _currentInstance.GetType();
            var mi = type.GetMethod(methodName);
            mi.Invoke(_currentInstance, parameters);
        }
    }
