using System;
using System.Threading.Tasks;
namespace XYZ{
public class Program
{
    public static void Main(string[] args)  
    {
        Task<string> t = Task.Run( () =>
        { 
            return FindPort.GetPort(10);
        });
        t.Wait();
        if(t.Result == null) 
            Console.WriteLine($"Unable To Find Port");
        else
            Console.WriteLine($"[DONE] Port => {t.Result} Received");
        
        // Console.ReadLine();
    }
}
}
using System;
using System.IO.Ports;
public static class FindPort
{
    public static string GetPort(int retryCount)
    {
        string portString = null;
        int count = 0;
        while( (portString = FindPort.GetPortString() ) == null) {
            System.Threading.Thread.Sleep(1000);
            if(count > retryCount) break;
            count++;
        }
        return  portString;
    }
    static string GetPortString()
    {
        SerialPort currentPort = null;
        string[] portList = SerialPort.GetPortNames();
            
        foreach (string port in portList)
        {
            // Console.WriteLine($"Trying Port {port}");
            if (port != "COM1")
            {
                try
                {
                    currentPort = new SerialPort(port, 115200);
                    if (!currentPort.IsOpen)
                    {
                        currentPort.ReadTimeout = 2000;
                        currentPort.WriteTimeout = 2000;
                        currentPort.Open();
                        // Console.WriteLine($"Opened Port {port}");
                        currentPort.Write("connect");
                        string received = currentPort.ReadLine();
                        if(received.Contains("Hub"))
                        {
                            // Console.WriteLine($"Opened Port {port} and received {received}");
                            currentPort.Write("close");
                            currentPort.Close();
                            
                            return port;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Do nothing
                    Console.WriteLine(e.Message);
                    
                    if(currentPort.IsOpen)
                    {
                        currentPort.Write("close");
                        currentPort.Close();
                    }
                }
            }
        }
        // Console.WriteLine($"Unable To Find Port => PortLength : {portList.Length}");
        return null;
    }
}
