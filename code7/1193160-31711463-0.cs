        static void Main()
        {
            OpenDevice();
            RequestPIN();
            if (GetResultPIN())
            {
                // do something with the PIN:
                var pin = mIPAD.pin.EPB;
                // ...
            }
            else
            {
                Console.WriteLine("0000");
            }
        }
        public static bool GetResultPIN()
        {
            TimeSpan timeout = TimeSpan.FromSeconds(30);
            System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
            SW.Start();
            while (mIPAD.getStatusCode() != 0 && SW.Elapsed < timeout)
            {
                System.Threading.Thread.Sleep(50); // small call to prevent CPU usage ramping to 100%
            }
            return (mIPAD.getStatusCode() == 0);
        }
