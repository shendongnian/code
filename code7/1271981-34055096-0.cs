    using System.Collections.Concurrent;
    
    public static class Email
    {
        private
        static
        readonly
        ConcurrentDictionary<int, bool> dict =
        new ConcurrentDictionary<int, bool>()
        ;
        public static bool TrySend(DateTime timestamp, int SensorID)
        {
            if (!dict.TryAdd(SensorID, true)) return false;
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("@gmail.com", ""),
                EnableSsl = true
            };
            client.Send("@gmail.com",
                        "@gmail.com",
                        "Alarm Alert!",
                        "There was an alarm today at: " +
                        timestamp  +
                        " on Sensor: " +
                        SensorID));
            Console.WriteLine("Sent SensorID: " + SensorID.ToString());
            return true;
        }
    }
