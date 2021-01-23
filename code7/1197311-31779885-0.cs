    private static async Task UDPListener(object obj)
    {
        using (var udpClient = new UdpClient(10545))
        {
            string rMessage = "";
            string[] rArgs = new string[0];
            while (true)
            {
                //IPEndPoint object will allow us to read datagrams sent from any source.
                var receivedResults = await udpClient.ReceiveAsync();
                rMessage += Encoding.ASCII.GetString(receivedResults.Buffer);
                rArgs = rMessage.Split(new char[] { ':' });
                if( rArgs[0] == "HELLO")
                {
                    Console.Write("Received HELLO from server.");
                    byte[] data = new byte[512];
                    byte[] result;
                    SHA512 shaM = new SHA512Managed();
                    result = shaM.ComputeHash(Encoding.UTF8.GetBytes(obj.password.Text));
                    var hash = BitConverter.ToString(result).Replace("-", "");
                    send_message("127.0.0.1", 10545, 10545, "AUTH:" + obj.login.Text + ":" + hash);
                }
            }
        }
    }
