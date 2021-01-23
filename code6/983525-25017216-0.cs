    using System;
    using System.Text;
    using ZeroMQ;
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var context = ZmqContext.Create())
            {
                using (ZmqSocket publisher = context.CreateSocket(SocketType.PUB))
                {
                    // your first potential issue lies here, if you're not
                    // populating your addresses properly then you're not going to
                    // bind appropriately
                    // Test by hard coding the address
                    publisher.Bind("tcp://127.0.0.1:5000");
                    int msgIndex = 0;
                    while (true)
                    {
                        // your second potential issue lies here, if your logic
                        // short circuits your send, that'll throw a wrench in the
                        // works
                        // Test by removing the logic and just sending a bunch of
                        // messages
                        var msg = "Message: " + msgIndex; // simplify
                        Console.WriteLine("Publishing: " + msg);
                        socket.Send(msg, Encoding.UTF8);
                        Thread.Sleep(500); // hard code
                        msgIndex++;
                        if (msgIndex > 1500) break; // hard code the break
                    }
                }
            }
        }
    }
