    private void MSocket_MessageReceived(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args)
    {
        byte[] data;
    
        try
        {
            int length = 0;
    
            using (DataReader reader = args.GetDataReader())
            {
                reader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
    
                length = (int)reader.UnconsumedBufferLength;
                data = new byte[length];
    
                reader.ReadBytes(data);
            }
    
            string json = System.Text.Encoding.UTF8.GetString(data, 0, length);
    
            PacketData packet = JsonConvert.DeserializeObject<PacketData>(json);
        }
        catch (Exception ex)
        {
            string a = ex.Message;
        }
    }
