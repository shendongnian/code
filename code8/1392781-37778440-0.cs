        public void Boot()
        {
            if (KernelPartition != null)
            {
                throw new InvalidOperationException("Kernel partition already exists.");
            }
            Log.TraceEvent(TraceEventType.Verbose, 0, "Initiating startup sequence...");
            KernelPartition = AppDomain.CreateDomain("Kernel", null, new AppDomainSetup() { ApplicationName = "krnl", ShadowCopyFiles = "true" });
            KernelPartition.DomainUnload += KernelPartition_DomainUnload;
            string engineClassName = null;
            string engineAssemblyName = null;
            try
            {
                var engineTypeId = ConfigurationManager.AppSettings["engineTypeId"];
                engineClassName = engineTypeId.Split(',')[0].Trim();
                engineAssemblyName = engineTypeId.Substring(engineClassName.Length + 1).Trim();
            }
            catch (Exception)
            {
                Log.TraceEvent(TraceEventType.Verbose, 0, "Configuration errors detected. Attempting defaults...");
                engineClassName = "Contoso.Kernel.Turbine";
                engineAssemblyName = "Contoso.Kernel";
            }
            
            try
            {
                // FOCUS ON THE NEXT LINE
                KernelTurbine = (ITcsKernel)KernelPartition.CreateInstanceAndUnwrap(engineAssemblyName, engineClassName);
                Log.TraceEvent(TraceEventType.Verbose, 0, "Kernel connection established.");
            }
            catch (Exception ex)
            {
                Log.TraceEvent(TraceEventType.Verbose, 0, "Failed to establish communication channel with the kernel with the following exception:\n{0}", ex.ToString());
            }
            if (KernelTurbine == null)
            {
                InitializeRestart();
            }
            else
            {
                try
                {
                    Start();
                    Log.TraceEvent(TraceEventType.Verbose, 0, "Startup sequence completed.");
                    KernelTurbine.RebootDelegate = Reboot;
                    DisposeRestartSecond();
                }
                catch (Exception ex)
                {
                    string message = string.Format("The startup sequence failed with the following exception:{0}{1}", Environment.NewLine, ex.ToString());
                    Log.TraceEvent(TraceEventType.Error, 0, message);
                    InitializeRestart();
                }
            }
        }
