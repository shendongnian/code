    for (int i = 50; i <= 150; i++){
        // Try Connect to Python
        try{
            ip = "10.10.10."+i.ToString();
            // Set timer to break Client connection
            tConnectTimeout = new System.Timers.Timer(100);
            tConnectTimeout.Elapsed += new System.Timers.ElapsedEventHandler(tConnectTimeout_Elapsed);
            tConnectTimeout.Start();
            // Connect to Client
            cli = new TcpClient();
            cli.Connect(ip, 8888);
                     
            Console.WriteLine(ip + " - Yes");
            ipAddresses.Add(ip);
            cli.Close();
        } catch (ObjectDisposedException ex) {
        } catch (SocketException ex) {
            tConnectTimeout.Stop();
            tConnectTimeout.Dispose();
            Console.WriteLine(ip + " - No");
        }
        finally
        {
             tConnectTimeout.Stop();
             tConnectTimeout.Dispose();
        }
    }
    tConnectTimeout.Stop();
    btnStart.Sensitive = true;
    foreach(string ipa in ipAddresses){
        cbAddresses.AppendText(ipa);
    }
    cbAddresses.Sensitive = true;
