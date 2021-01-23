    static int i=0
    static void send_covert_cmd() {
            if (i < commands.Count) {
                trans_aac(commands[i]);
                i++;
            }
    }
    //Start 4 process
    sendcommand();
    sendcommand();
    sendcommand();
    sendcommand();
    static void trans_aac(string command) {
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = command;
            proc.EnableRaisingEvents = true;
            proc.Exited += ProcessExited;
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
    }
    static void ProcessExited(object sender, EventArgs e) {
            send_covert_cmd();
    }
