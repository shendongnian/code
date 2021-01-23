        public static void getFileNameByProcess(string process)
        {
            foreach (Process p in Process.GetProcessesByName(process))
            {
                string[] split = p.MainWindowTitle.Split('-');
                if (split.Length > 0)
                    Console.WriteLine("\"" + split[0].Trim() + "\"");
            }
        }
