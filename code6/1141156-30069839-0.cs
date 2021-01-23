    public class MyTcpClient
    {
       private static int Counter = 0;
       public int Id
       {
          get;
          private set;
       } 
       public TcpClient TcpClient
       {
          get;
          private set;
       }
       public MyTcpClient(TcpClient tcpClient)
       {
          if (tcpClient == null)
          {
             throw new ArgumentNullException("tcpClient") 
          }
          
          this.TcpClient = tcpClient;
          this.Id = ++MyTcpClient.Counter;   
       }    
    }
