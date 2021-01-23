    public static void ConnectToRDP(string domain, string server, string user, string password)
        {
            Process rdcProcess = new Process();
            rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
            rdcProcess.StartInfo.Arguments = string.Format("/generic:TERMSRV/{0} /user:", server) + string.Format(@"{0}\{1} /pass:{2}", domain, user, password);
            rdcProcess.Start();
            rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
            rdcProcess.StartInfo.Arguments = string.Format("/v {0}", server); 
            rdcProcess.Start();
        }
