        /// <summary>
        /// The process instance used to execute netsh.
        /// </summary>
        private static readonly Process NetshProcess = new Process
                                                 {
                                                     StartInfo =
                                                         {
                                                             FileName = "netsh.exe",
                                                             RedirectStandardOutput = true,
                                                             UseShellExecute = false
                                                         }
                                                 };
        /// <summary>
        /// The main program.
        /// </summary>
        /// <returns>
        /// Nonzero if error.
        /// </returns>
        public static int Main()
        {
            // The first step is to get the subscriber ID.
            NetshProcess.StartInfo.Arguments = "mbn show ready *";
            var netshResultStrings = RunNetShProcess();
            var subIdStr = netshResultStrings.ElementAtOrDefault(5);
            var iccIdStr = netshResultStrings.ElementAtOrDefault(6);
            string lastValue;
            if (subIdStr == null || (lastValue = subIdStr.Trim(' ').Split(':').LastOrDefault()) == null)
            {
                throw new Exception("Could not determine Subscriber ID.");
            }
            var subscriberIdStr = lastValue.Trim(' ');
            Console.WriteLine("The subscriber ID is " + subscriberIdStr);
        }
        /// <summary>
        /// Run the netsh process.  StartInfo.Arguments for NetshProcess must be properly set prior to making this call. 
        /// </summary>
        /// <returns>
        /// An string array containing one element for each line of text returned by netsh.
        /// </returns>
        private static string[] RunNetShProcess()
        {
            NetshProcess.Start();
            var netshResult = NetshProcess.StandardOutput.ReadToEnd();
            if (!NetshProcess.WaitForExit(10000))
            {
                throw new Exception("Netsh command '" + NetshProcess.StartInfo.Arguments + "' did not exit.");
            }
            var netshResultStrings = netshResult.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return netshResultStrings;
        }
