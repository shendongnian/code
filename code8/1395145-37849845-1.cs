        static void Main(string[] args)
        {
            if (args == null ||
                args.Length <= 0 ||
                !args[0].Equals(
                    "/SpecialParameter", 
                    StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            // Do something if the /SpecialParameter exists.....
        }
        private static void StartAProcess(string proc)
        {
            var ps = new ProcessStartInfo(proc);
            ps.UseShellExecute = false;
            ps.Arguments = "/SpecialParameter";
            var p = Process.Start(ps);
            p.WaitForExit();
        }
