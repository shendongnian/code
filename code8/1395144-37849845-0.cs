        private static void StartAProcess(string proc)
        {
            var ps = new ProcessStartInfo(proc);
            ps.UseShellExecute = false;
            var p = Process.Start(ps);
            p.WaitForExit();
        }
