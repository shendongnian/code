    private void refreshbtn_Click(object sender, EventArgs e)
    {
        if (tokenSource != null) //check if its even initialized or not
            tokenSource.Cancel();
    
        lstNetworks.Items.Clear();
        string gate_ip = NetworkGateway();
        //Extracting and pinging all other ip's.
    
        tokenSource = new CancellationTokenSource();
    
        string[] array = gate_ip.Split('.');
    
        List<Task> tasks = new List<Task>();
        for (int i = 1; i <= 255; i++)
        {
            string ping_var = array[0] + "." + array[1] + "." + array[2] + "." + i;
    
            var task = Task.Factory.StartNew(() =>
            {
                if (tokenSource.Token.IsCancellationRequested) return;
    
                //time in milliseconds           
                Ping(ping_var, 1, 4000);
            }, tokenSource.Token);
            tasks.Add(task);
        }
        Task.WaitAll(tasks.ToArray(), tokenSource.Token);
    }
    
    public void Ping(string host, int attempts, int timeout)
    {
        try
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            ping.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);
            ping.SendAsync(host, timeout, host);
        }
        catch
        {
            // Do nothing and let it try again until the attempts are exausted.
            // Exceptions are thrown for normal ping failurs like address lookup
            // failed.  For this reason we are supressing errors.
        }
    }
