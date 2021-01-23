    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    
    namespace Blaster
    {
        class Blaster
        {
            UdpClient client;
            IPEndPoint outPoint;
            IPEndPoint inPoint;
            public int oPort = 7777;
            public int iPort = 7778;
            public string hostName = "localhost";
            public int stepNum = 0;
            const int rate = 1000;
            public System.Timers.Timer clock;
            Thread listener;
    
            static void Main(string[] args)
            {
                Blaster b = new Blaster();
                b.run();
            }
            Blaster()
            {
                client = new UdpClient();
                outPoint = new IPEndPoint(Dns.GetHostAddresses(hostName)[0], oPort);
                inPoint = new IPEndPoint(Dns.GetHostAddresses(hostName)[0], iPort);
            }
            void run()
            {
                this.stepNum = 0;
                listener = new Thread(new ThreadStart(translater));
                listener.IsBackground = true;
                listener.Start();
                Console.WriteLine("Press Enter to do a send loop...\n");
                Console.ReadLine();
                Console.WriteLine("started at {0:HH:mm:ss.fff}", DateTime.Now);
                start();
                Console.WriteLine("Press Enter to stop");
                Console.ReadLine();
                stop();
                client.Close();
            }
            void stop()
            {
                clock.Stop();
                clock.Dispose();
            }
            void start()
            {
                clock = new System.Timers.Timer(rate);
                clock.Elapsed += send;
                clock.AutoReset = true;
                clock.Enabled = true;
            }
            void send(Object source, System.Timers.ElapsedEventArgs e)
            {
                Console.WriteLine("sending: {0}", stepNum);
                Byte[] sendBytes = Encoding.ASCII.GetBytes(message());
                try
                {
                    client.Send(sendBytes, sendBytes.Length, outPoint);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.ToString());
                }
            }
            string message()
            {
                Packet p = new Packet();
                p.id = "car";
                p.start = DateTime.Now;
                p.x = 1.2f;
                p.y = 0.4f;
                p.z = 4.5f;
                p.step = stepNum++;
                string json = JsonConvert.SerializeObject(p);
                return json;
            }
            void translater()
            {
                UdpClient server = new UdpClient();
                Byte[] data = new byte[0];
                server.Client.Bind(inPoint);
                while (true)
                {
                    try
                    {
                        data = server.Receive(ref inPoint);
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("Blaster.translater: recieve data error: " + err.Message);
                        client.Close();
                        return;
                    }
                    string json = Encoding.ASCII.GetString(data);
                    Console.WriteLine(json);
                    Packet p = JsonConvert.DeserializeObject<Packet>(json);
                }
            }
        }
    }
