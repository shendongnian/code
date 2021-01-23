    internal class ProcessInvoker
    {
        /// <summary>
        /// Invokes the host process for test service
        /// </summary>
        public static void InvokeDummyService()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ProcessStartInfo info = new ProcessStartInfo(Path.Combine(path, "DummyService.exe"));
            info.UseShellExecute = true;
            info.WorkingDirectory = path;
            var process = Process.Start(info);
        }
        /// <summary>
        /// Kills the process of service host
        /// </summary>
        public static void KillDummyService()
        {
            Process.GetProcessesByName("DummyService").ToList().ForEach(x => x.Kill());
        }
    }
