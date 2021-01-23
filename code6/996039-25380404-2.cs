    public void Send(string message, NetworkStream stream) {
      byte[] strbuf = System.Text.Encoding.UTF8.GetBytes(message);
      byte[] intbuf = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(strbuf.Length));
      stream.Write(intbuf, 0, intbuf.Length);
      stream.Write(strbuf, 0, strbuf.Length);
    }
