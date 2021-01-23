    [System.Runtime.InteropServices.DllImport("Kernel32.Dll", EntryPoint = "Wow64EnableWow64FsRedirection")]
    public static extern bool EnableWow64FSRedirection(bool enable);
            EnableWow64FSRedirection(false);
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.UseShellExecute = false;
                psi.FileName = @"c:\windows\system32\djoin.exe";
                psi.RedirectStandardOutput = true;
                psi.Arguments = " /C toast ";
                using (Process proc = Process.Start(psi))
                {
                    using (System.IO.StreamReader reader = proc.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        MessageBox.Show(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            EnableWow64FSRedirection(true);
