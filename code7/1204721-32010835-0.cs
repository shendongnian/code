    [Serializable]
    [XmlType(TypeName = "IPEndPoint")]
    public class IPEndPoint
    {
      private System.Net.IPEndPoint _EndPoint;
      private string _Address;
      private int _Port;
      public string Address 
      {
        get { return _Address; }
        set 
        {
          _Address = value;
          _EndPoint = new System.Net.IPEndPoint(IPAddress.Parse(_Address), _Port);
        }
      }
      public int Port 
      {
        get { return _Port; }
        set
        {
          _Port = value;
          _EndPoint = new System.Net.IPEndPoint(IPAddress.Parse(_Address), _Port);
        }
      }
      public IPEndPoint()
      {
        Address = "127.0.0.1";
        Port = 0;
        _EndPoint = new System.Net.IPEndPoint(IPAddress.Loopback, 0);
      }
      public IPEndPoint(IPAddress address, int port)
      {
        Address = address.ToString();
        Port = port;
        _EndPoint = new System.Net.IPEndPoint(address, port);
      }
      public IPEndPoint(string address, int port)
      {
        Address = address;
        Port = port;
        _EndPoint = new System.Net.IPEndPoint(IPAddress.Parse(address), port);
      }
      public System.Net.IPEndPoint Value 
      { 
        get { return _EndPoint; } 
      }
      public override string ToString()
      {
        return _EndPoint.ToString();
      }
    }
