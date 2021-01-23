    public static async Task ExecuteCommandAsync(object command)
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
            await ConsumeReader(proc.StandardOutput);
        }
        catch (Exception objException)
        {
            Log.addLog(objException.Message);
        }
    }
    async static Task ConsumeReader(TextReader reader)
    {
        string text;
        while ((text = await reader.ReadLineAsync()) != null)
        {
            Log.addLog(text);
        }
    }
