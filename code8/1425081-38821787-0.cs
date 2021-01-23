                public bool Initialise()
        {
            //  Get the manifest resource name.
            var resouceName = GetBridgeManifestResourceName();
            //  We'll now try and get the bridge library path.
            string bridgeLibraryPath = string.Empty;
            try
            {
               int index = resouceName.LastIndexOf('.') > 0 ? resouceName.LastIndexOf('.', resouceName.LastIndexOf('.') - 1) : -1;
               string resouceNameTrimed = resouceName.Substring(index+1,resouceName.Length - (index+1));
               string ResourcePath = String.Format(@"{0}\{1}", System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),resouceNameTrimed);
               using (var resourceStream = File.OpenRead(ResourcePath))
                {
                    //  Set the temporary path..
                    bridgeLibraryPath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".dll";
                    using (var tempStream = File.Create(bridgeLibraryPath))
                    {
                        resourceStream.CopyTo(tempStream);
                    }
                }
            }
            catch (Exception exception)
            {
                //  Log the exception.
                Logging.Error("NativeBridge: Failed to extract the bridge library. The manifest path is '" +
                              bridgeLibraryPath + "'", exception);
                return false;
            }
            //  Load the bridge library.
            try
            {
                libraryHandle = Kernel32.LoadLibrary(bridgeLibraryPath);
            }
            catch (Exception exception)
            {
                //  Log the exception.
                Logging.Error("NativeBridge: Exception loading the bridge library.", exception);
            }
            //  If the library hasn't been loaded, log the last windows error.
            if (libraryHandle == IntPtr.Zero)
            {
                Logging.Error("NativeBridge: Failure to load the brige library.",
                              new Win32Exception(Marshal.GetLastWin32Error()));
                return false;
            }
            Logging.Log("Bridge Initialised");
            //  We've successfully loaded the bridge library.
            return true;
        }
