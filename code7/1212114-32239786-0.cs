    static IPAddress ipAddress = Dns.GetHostAddresses(Dns.GetHostName())[1];
    TcpListener smoClient = new TcpListener(ipAddress ,55962);
    try
    {
         smoClient.Start();
    
         MessageBox.Show("Connected");
    }
    catch (SocketException se) 
    {
         Console.WriteLine(se.ToString());         
    }
    finally
    {
        smoClient.Close();
    }
