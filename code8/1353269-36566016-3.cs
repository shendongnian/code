        static void Main(string[] args)
        {
            var lines = GetSoft("Get-ItemProperty HKLM:\\Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\*")
                .Union(GetSoft("Get-ItemProperty HKLM:\\Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\*"))
                .Distinct()
                .ToList();
            lines.Sort();
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(lines.Count);
            Console.ReadLine();
        }
        public static IEnumerable<string> GetSoft(string key)
        {
            Process p1 = new Process();
            ProcessStartInfo psi1 = new ProcessStartInfo("powershell",
                key + " | Select-Object DisplayName")
            {
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            p1.StartInfo = psi1;
            p1.StartInfo.UseShellExecute = false;
            p1.StartInfo.Verb = "runas";
            p1.Start();
            var output = p1.StandardOutput.ReadToEnd();
            var result= output.Split('\r', '\n').Select(s => s.Trim()).Where(s => !String.IsNullOrWhiteSpace(s));
            p1.WaitForExit(400);
            return result;
        } 
    }
