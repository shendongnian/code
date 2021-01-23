    public class LetsChat : Hub
    {
        private static readonly System.Timers.Timer _timer = new System.Timers.Timer();
        static LetsChat()
        {
            _timer.Interval = 1000;
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }
        static void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            send("Message");
        }
        public void send(string message)
        {
            //Thread.Sleep(1000);
            var diffInSeconds = (Convert.ToDateTime(dateTime1) - dateTime2).TotalSeconds;
            Clients.All.addMessage(message);
            Clients.All.addTest(diffInSeconds.ToString());
            //Clients.All.addTest(dateTime1.ToString());
        }
    }
