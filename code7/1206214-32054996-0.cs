    public class Wrapped<T> where T: struct
    {
        public Wrapped(T t)
        {
            Elem = t;
        }
        public T Elem { get; set;}
    }
    class MCP
    {
        public Wrapped<byte> McpByte { get; set; }
    };
    class IO
    { 
        public Wrapped<byte> IoByte { get; set; }
    };
    var b = new Wrapped<byte>(someByte);
    var mcp = new Mcp { McpByte = b };
    var io = new Io { IoByte = b };
    mcp.McpByte = someOtherByte;
    Assert.Equal(someOtherByte, io.IoByte);
