        private void button1_Click(object sender, EventArgs e)
        {
            //pids.Clear();
            Process myprocess = new Process();
            myprocess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\syswow64\mstsc.exe");
            myprocess.StartInfo.Arguments = "C:\\rdp\\RemoteIn.rdp";
            myprocess.Start();
            Thread.Sleep(100);
            int id = Process.GetProcessesByName("mstsc").FirstOrDefault(x => !pids.Any(y => y == x.Id)).Id;
            pids.Add(id);
        }
