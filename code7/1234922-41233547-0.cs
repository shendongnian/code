    internal static class P4BridgeLoader
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);
        private static void ExtractResource(string resourceName, string outPath)
        {
            using (System.IO.Stream dllStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                try
                {
                    // Copy the assembly to the temporary file
                    using (System.IO.Stream outFile = System.IO.File.Create(outPath))
                    {
                        dllStream.CopyTo(outFile);
                    }
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// Loads the correct version of p4bridge.dll, based on the bit with of the current architecture.
        /// Note that this is called by the module initializer, which gets called just after this module
        /// is loaded but before any other code inside it is executed.
        /// </summary>
        internal static void LoadP4BridgeDLL()
        {
            // Figure out where we are going to put the p4bridge.dll once we've extracted it
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string assemblyPath = Uri.UnescapeDataString(uri.Path);
            string assemblyDir = Path.GetDirectoryName(assemblyPath);
            string dllPath = Path.Combine(assemblyDir, "p4bridge.dll");
            // Extract the correct architecture version of p4bridge.dll from our assembly's resources
            string resourceName = Environment.Is64BitProcess ? "Perforce.P4.p4bridge64.dll" : "Perforce.P4.p4bridge86.dll";
            // If the dll already exists, then we shouldn't have to try extracting it again unless it fails to load
            if (System.IO.File.Exists(dllPath))
            {
                // Attempt to load the DLL
                if (LoadLibrary(dllPath) != IntPtr.Zero)
                    return;
            }
            // DLL either wasn't already extracted, or failed to load. Try again!
            ExtractResource(resourceName, dllPath);
            // Attempt to load the DLL
            IntPtr h = LoadLibrary(dllPath);
            System.Diagnostics.Debug.Assert(h != IntPtr.Zero, "Unable to load library " + dllPath);
        }
    }
