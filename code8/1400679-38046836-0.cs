    class SmsDetails
    {
        public string Subscriber { get; set; }
        public string Message { get; set; }
        public DateTime SendOn { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SqlDataReader schedule = null; // Initialize the reader as appropriate.
            while (schedule.Read())
            {
                var det = new SmsDetails();
                //.
                //.
                //.
                det.SendOn = schedule.GetDateTime(2);
                ThreadPool.QueueUserWorkItem(ScheduleSending, det);
            }
        }
        static void ScheduleSending(object Details)
        {
            var smsd = Details as SmsDetails;
            if (smsd.SendOn > DateTime.Now)
            {
                var waitInterval = DateTime.Now - smsd.SendOn;
                Thread.Sleep(waitInterval);
                SendSms(smsd.Subscriber, smsd.Message);
            }
        }
        static void SendSms(string PhoneNumber, string Message)
        {
            // Send it out
        }
    }
