    static void Main(string[] args)
    {
        byte[] data = new byte[256];
        byte[] recived = new byte[256];
        data[0] = 0x00;
        data[1] = 0xA4;
        data[2] = 0x04;
        data[3] = 0x00;
        data[4] = 0x00;
        data[5] = 0x00;
        data[6] = 0x00;
        using (System.IO.Ports.SerialPort sp = new System.IO.Ports.SerialPort("COM4", 38400, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One))
        {
            try 
            {
                sp.Open();
                sp.Write(data, 0, 7);
                
                int bytesRead = sp.Read(recived, 0, received.Length);
                if (bytesRead != 0)
                {
                    string s = Encoding.ASCII.GetString(received, 0, bytesRead);
                    Console.WriteLine(s);
                    Console.ReadKey();
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            } 
        }   
    }
