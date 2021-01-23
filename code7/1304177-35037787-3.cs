    private void butSend_Click(object sender, EventArgs e)
    {
        txtStatus.Text = "Pinging";
        Pinger.SendAsync(txtHost, null);
    }
    private void butCancel_Click(object sender, EventArgs e)
    {
        Thread t = new Thread(Pinger.SendAsyncCancel);
        t.Start();
    }
