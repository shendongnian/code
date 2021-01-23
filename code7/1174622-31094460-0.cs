        private static void MakeRequest()
        {
            WebRequest req = null;
            try
            {
                req = WebRequest.Create("http://www.wg.net.pl");
                req.Timeout = 10;                
                req.GetResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                req.Timeout = 10000;
                req.GetResponse(); // This as well results in TimeOut exception
            }
        }
