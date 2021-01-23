    using System;
    using System.Net;
    using System.Text;
    using System.Threading;
    
    static class P {
        static void Main() {
            using (var http = new HttpListener())
            {
                http.Prefixes.Add("http://localhost:20000/");
                http.Start();
    
                ThreadPool.QueueUserWorkItem(delegate {
                    try {
                        while (true) {
                            var ctx = http.GetContext();
                            Console.Write("."); // <===== this
                            var buffer = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
                            ctx.Response.OutputStream.Write(buffer, 0, buffer.Length);
                            ctx.Response.OutputStream.Close();
                        }
                    }
                    catch { }
                });
    
                Console.WriteLine("Running for 5 minutes...");
                Thread.Sleep(TimeSpan.FromMinutes(5));
                http.Stop();
            }
        }
    }
