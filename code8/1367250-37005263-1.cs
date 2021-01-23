    private void SocketMessageReceived(DatagramSocket sender, DatagramSocketMessageReceivedEventArgs args)
    {
        try
        {
            using (var reader = args.GetDataReader())
            {
                byte[] response = new byte[48];
                reader.ReadBytes(response);
                YourMethodToParseNetworkTime(response);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
        }
    }
