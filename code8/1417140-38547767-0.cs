    public void DataToSend(IMessage message)
    {
      CodedOutputStream output = new CodedOutputStream(m_ostream.BaseStream, true);
      output.WriteMessage(message);
      output.Flush();
      (m_ostream.BaseStream as MemoryStream).SetLength(0); // reset stream for next packet(s)
      m_client.GetServerConnection().GetClient().Send(m_packet, message.CalculateSize() + 1);
    }
