    public static class AppTimer
    {
        static AppTimer()
        {
            Events = new Dictionary<string, Event>();
        }
        public static Dictionary<string, Event> Events { get; set; }
        public static void AddEvent(string eventType, Event newEvent)
        {
            if (Events.ContainsKey(eventType))
            {
                Events[eventType].Timer.Stop();
                Events[eventType] = null;
                Events.Remove(eventType);
            }
            Events.Add(eventType, newEvent);
        }
        private static int CalculateTimerInterval(int minute)
        {
            if (minute < 0) minute = 60;
            var now = DateTime.Now;
            var future = new DateTime();
            // We want to run right away
            if (minute == 0)
            {
                future = now.AddSeconds(1.5);
            }
            else
            {
                future = now.AddMinutes((minute - (now.Minute%minute)))
                    .AddSeconds(now.Second*-1)
                    .AddMilliseconds(now.Millisecond*-1);
            }
            var interval = future - now;
            return (int)interval.TotalMilliseconds;
        }
        public class Event
        {
            public Event(Action tick, int interval)
            {
                this.Timer = new Timer { Interval = CalculateTimerInterval(interval) };
                this.Timer.AutoReset = false;
                this.Timer.Elapsed += (sender, args) =>
                {
                        tick?.Invoke();
                    if (this.Interval > 0)
                    {
                        this.Timer.Interval = CalculateTimerInterval(this.Interval);
                    }
                };
                this.Interval = interval;
                this.Timer.Start();
            }
            public Timer Timer { get; set; }
            public int Interval { get; set; }
            public void ChangeInterval(int newInterval)
            {
                this.Interval = newInterval;
                this.Timer.Interval = CalculateTimerInterval(newInterval);
            }
        }
    }
