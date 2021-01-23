    internal class Program
    {
    private static void Main(string[] args)
    {
        SenderThreadClass stc1 = SenderThreadClass("192.168.1.2", 5052);
        SenderThreadClass stc2 = SenderThreadClass("192.168.1.2", 5052);
        Thread one = new Thread(()=> stc1.SendFile(new FileInfo(@"1.doc")));
        one.Start();
        Thread two = new Thread(()=> stc2.SendFile(new FileInfo(@"2.docx")));
        two.Start();
    }
    }
    
    public class SenderThreadClass
    {
    private TcpClient client;
    private NetworkStream stream;
    
    public SenderThreadClass(string serverIP, int serverPort)
    {
       client = new TcpClient(serverIP, serverPort);
       stream = client.GetStream();
    }
    
    public void SendFile(FileInfo file)
    {
    byte[] id = BitConverter.GetBytes((ushort)1);
    byte[] size = BitConverter.GetBytes(file.Length);
    byte[] fileName = Encoding.UTF8.GetBytes(file.Name);
    byte[] fileNameLength = BitConverter.GetBytes((ushort)fileName.Length);
    byte[] fileInfo = new byte[12 + fileName.Length];
    
    id.CopyTo(fileInfo, 0);
    size.CopyTo(fileInfo, 2);
    fileNameLength.CopyTo(fileInfo, 10);
    fileName.CopyTo(fileInfo, 12);
    
    stream.Write(fileInfo, 0, fileInfo.Length); //Размер файла, имя
    
    byte[] buffer = new byte[1024 * 32];
    int count;
    long sended = 0;
    using (FileStream fileStream = new FileStream(file.FullName, FileMode.Open))
    while ((count = fileStream.Read(buffer, 0, buffer.Length)) > 0)
    {
    stream.Write(buffer, 0, count);
    sended += count;
    Console.WriteLine("{0} bytes sended.", sended);
    }
    stream.Flush();
    }
    }
