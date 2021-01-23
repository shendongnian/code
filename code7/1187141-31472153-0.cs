      public class MemoryManagement
        {
            /// <summary>
            /// Clear un wanted memory
            /// </summary>
            public static void FlushMemory()
            {
                try
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                    }
                }
                catch (Exception e)
                {
                }
            }
    
            /// <summary>
            /// set process working size
            /// </summary>
            /// <param name="process">Gets process</param>
            /// <param name="minimumWorkingSetSize">Gets minimum working size</param>
            /// <param name="maximumWorkingSetSize">Gets maximum working size</param>
            /// <returns>Returns value</returns>
            [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet =
              CharSet.Ansi, SetLastError = true)]
            private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
        }
