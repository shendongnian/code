    private void MSocket_MessageReceived(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args)
    {
        try
        {
            using (DataReader reader = args.GetDataReader())
            {
                reader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
    
                string json = reader.ReadString(reader.UnconsumedBufferLength);
    
                PacketData packet = JsonConvert.DeserializeObject<PacketData>(json);
            }
        }
        catch (Exception ex)
        {
            string a = ex.Message;
        }
    }
