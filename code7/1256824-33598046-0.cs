    namespace NetLib {
    
      class Header {
    
        public string Name { get; }
        public string Value { get; }
    
        public Header(string name, string value) {
          this.Name = name;
          this.Value = value;
        }
    
      }
    
      class NetClient {
    
        public string Host { get; private set; }
        public int Port { get; private set; }
        public List<Header> Headers { get; private set; }
    
        public NetClient(string host, int port) {
          this.Host = host;
          this.Port = port;
          this.Headers = new List<Header>();
        }
    
      }
    
    }
