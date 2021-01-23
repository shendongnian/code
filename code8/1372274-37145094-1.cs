    private void Func() {
        try {
            if (pipeReader != null) {
                Action<string> updateStatus = message =>
                {
                    if (statusesDict.ContainsKey(message))
                        statusLabel.Text = statusesDict[message];
                    else
                        statusLabel.Text = "!UNKNOWN STATUS!";
                    if (message != "CARDREADER_USER_EXISTS") {
                        this.BackColor = defaultBgColor;
                        statusLabel.ForeColor = defaultForeColor;
                    } else {
                        this.BackColor = passOkBgColor;
                        statusLabel.ForeColor = passOkForeColor;
                    }
                    statusLabel.Refresh();
                };
                while(true) {
                    if (!npsc.IsConnected) {
                        npsc.Connect();
                        Thread.Sleep(500);
                        continue;
                    }
                    string msg_str;
                    while ((msg_strg = pipeReader.ReadLine()) != null) {
                        statusLabel.BeginInvoke(updateStatus, msg_str);
                        Thread.Sleep(300);
                    }
                }
            }
        } catch (Exception ex) {
            Log.Instance.Error("Exception: " + ex.Message);
        }
    }
