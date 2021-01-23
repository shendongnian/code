    namespace WaveSampe
    {
        using System;
        using System.IO;
        using System.ServiceModel;
        using System.ServiceModel.Description;
        using System.ServiceModel.Web;
    
        [ServiceContract]
        public interface IWaveService
        {
            [WebGet]
            Stream GetWave();
        }
        public class WaveService : IWaveService
        {
            public Stream GetWave()
            {
                var resp = WebOperationContext.Current.OutgoingResponse;
                resp.ContentType = "audio/wav";
                // Clear caches
                resp.Headers.Add(System.Net.HttpResponseHeader.CacheControl, "no-cache");
                resp.Headers.Add(System.Net.HttpResponseHeader.Pragma, "no-cache");
                resp.Headers.Add(System.Net.HttpResponseHeader.Expires, "0");
    
                // Wave example. Source is http://www-mmsp.ece.mcgill.ca/documents/audioformats/wave/Samples/AFsp/M1F1-Alaw-AFsp.wav
                return new FileStream("example.wav", FileMode.Open, FileAccess.Read, FileShare.Read);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                string baseAddress = "http://localhost:8000/WaveService";
                ServiceHost host = new ServiceHost(typeof(WaveService), new Uri(baseAddress));
                host.AddServiceEndpoint(typeof(IWaveService), new WebHttpBinding(), "").Behaviors.Add(new WebHttpBehavior());
                host.Open();
                Console.WriteLine("Service is running");
                Console.Write("Press ENTER to close the host");
                Console.ReadLine();
                host.Close();
            }
        }
    }
