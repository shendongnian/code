    private async void CheckPOSUG(object sender, EventArgs e) 
    {
        Panel[] panelUG = new Panel[]{pnlPOSUG1,pnlPOSUG2,pnlPOSUG3,pnlPOSUG4,pnlPOSUG5,pnlPOSUG6,pnlPOSUG7,pnlPOSUG8};
        Label[] LabelUG = new Label[]{lblUG1,lblUG2,lblUG3,lblUG4,lblUG5,lblUG6,lblUG7,lblUG8};
        Label[] lblSpdUG = new Label[] { lblSpdUG1, lblSpdUG2, lblSpdUG3, lblSpdUG4, lblSpdUG5, lblSpdUG6, lblSpdUG7, lblSpdUG8 };
        Task[] tasks = new Task[8];
        for (int x = 0; x < 8; x++)
        {
            tasks[x] = PingServer(x, panelUG[x], LabelUG[x], lblSpdUG[x]);
        }
        try
        {
            await Task.WhenAll(tasks);
        }
        catch (Exception e)
        {
            // handle as appropriate, e.g. log and exit program,
            // report expected, non-fatal exceptions, etc.
        }
    }
    async Task PingServer(int index, Panel panel, Label ugLabel, Label spdLabel)
    {
        // NOTE: String concatenation will automatically convert
        // non-string operands by calling calling ToString()
        string IP = "192.168.135.1" + (index + 1);
        var ping = new Ping();
        var reply = await ping.SendPingAsync(IP, 10 * 1000);
        ugLabel.Text = "POSBMS10" + x;
        if (reply.Status == IPStatus.Success)
        {
            spdLabel.Text = reply.RoundtripTime + " ms";
            // The Color struct already has named properties for known colors,
            // so no need to pass a string to look Lime up.
            panel.BackColor = Color.Lime;
        }
        else 
        {
            spdLabel.Text = "Nonaktif";
            panel.BackColor = Color.FromName("ButtonHighlight");
        }
    }
