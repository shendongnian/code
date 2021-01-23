    public static async Task<string> ExecuteCommandAsync(object command)
    {
        try
        {             
            System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            return await proc.StandardOutput.ReadToEndAsync();
        }
        catch (Exception objException)
        {
            return objException.Message;
        }
    }
