    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.RemoveOwnedForm(this);
                e.Cancel = true;
                Process[] AllProcess = Process.GetProcesses();
                for (int i = 0; i < AllProcess.Length; i++)
                {
                if (AllProcess[i].ProcessName.StartsWith("SmsAlertRemainder"))
                     {
                            AllProcess[i].Kill();
                      }
                }
               Application.Exit(e);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }
        }
