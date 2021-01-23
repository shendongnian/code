    private async void Button1_click(object sender, EventArgs e)
    {
        var TheClient = await getConnectionPDU();
    }
    private async Task<Client> getConnectionPDU()
    {
        // Client à retourné
        PrimS.Telnet.Client client = null;
        // Ouverture de la connection
        try
        {
            // --- Ouverture de la connexion
            client = new Client(rackToIP[selectedRack], addrPort, new System.Threading.CancellationToken());
            console.Text +=  client.Read();
            await Task.Delay(sleep);
            progressBar.Value = 20;
            // --- Username
            client.WriteLine(username + enter);
            await Task.Delay(sleep);
            progressBar.Value = 40;
            console.Text += "\n" + client.Read();
            await Task.Delay(sleep);
            progressBar.Value = 60;
            // --- Password
            client.WriteLine(password + enter);
            await Task.Delay(sleep);
            progressBar.Value = 80;
            console.Text += "\n" + client.Read();
            await Task.Delay(sleep);
            progressBar.Value = 100; 
        }
        catch (Exception e)
        {
            console.Text += "\n" + e.Message;
            client = null;
        }
        // Scroll to end
        scroller.ScrollToEnd();
        return client;
    }
