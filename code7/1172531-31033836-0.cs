        public class JustMine
    {
        public string Value { get; set; }
        public decimal Milliseconds { get; set; }
        public JustMine()
        {
            this.Milliseconds = DateTime.Now.Ticks / (decimal)TimeSpan.TicksPerMillisecond;
        }
    }
            List<JustMine> JustMine = new List<JustMine>();
            var now = DateTime.Now.Ticks / (decimal)TimeSpan.TicksPerMillisecond;
            var limit = 5000; // 5 seconds
            foreach(var item in JustMine.ToList())
            {
                if (now - item.Milliseconds >= limit)
                {
                    JustMine.Remove(item);
                }
            }
