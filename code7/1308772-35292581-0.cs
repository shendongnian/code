        private static void Main(string[] args)
        {
            if (args.Any())
            {
                try
                {
                    var proc = Process.GetCurrentProcess();
                    
                    Process[] processes = Process.GetProcessesByName(proc.ProcessName);
                    if (processes.Length > 1)
                    {
                        //iterate through all running target applications      
                        foreach (Process p in processes)
                        {
                            if (p.Id != proc.Id)
                            {
                                if (args[0] == "Item1")
                                    SendMessage(p.MainWindowHandle, Item1Value, IntPtr.Zero, IntPtr.Zero);
                                if (args[0] == "Item2")
                                    SendMessage(p.MainWindowHandle, Item2Value, IntPtr.Zero, IntPtr.Zero);
                                if (args[0] == "Item3")
                                    SendMessage(p.MainWindowHandle, Item3Value, IntPtr.Zero, IntPtr.Zero);
                                Environment.Exit(0);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Any())
            {
                if (args[0] == "Item1") Application.Run(new frmSelect(Item1Value));
                if (args[0] == "Item2") Application.Run(new frmSelect(Item2Value));
                if (args[0] == "Item3") Application.Run(new frmSelect(Item3Value));
            }
            else
            {
                Application.Run(new frmSelect());
            }
            
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hwnd, uint Msg, IntPtr wParam, IntPtr lParam);
        private const int Item1Value = 0xA123;
        private const int Item2Value = 0xA124;
        private const int Item3Value = 0xA125;
    }
