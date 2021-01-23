    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace AsyncFileStream
    {
      class Program
      {
        static void Main(string[] args)
        {
          FileStream fs = new FileStream("d:\\temp.txt", FileMode.Open);
          int size = (int)fs.Length;
    
          byte[] data = new byte[size];
    
          var result = 
              fs.BeginRead(data, 0, size, (ar) => Callback(fs, ar, data), null);
    
          if (result.CompletedSynchronously) Callback(fs, result, data);
    
          Console.ReadLine();
        }
    
        static void Callback(FileStream fs, IAsyncResult ar, byte[] data)
        {
          var bytesRead = fs.EndRead(ar);
    
          Console.WriteLine(UTF8Encoding.UTF8.GetString(data, 0, bytesRead));
        }
      }
    }
