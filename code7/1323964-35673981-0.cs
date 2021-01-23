    private List<string> Lines = new List<string>();
            public void WriteLog(string LogString)
            {
                if (this.ServerLogTextbox.InvokeRequired)
                {
                    SetTextCallback Recal = new SetTextCallback(WriteLog);
                    this.Invoke(Recal, new object[] {LogString});
                }
                else
                {
                    Lines.Add("[" + DateTime.Now.ToString("HH.mm.ss") + "]: " + LogString);
                    ServerLogTextbox.Lines = Lines.ToArray();
                }
            }
