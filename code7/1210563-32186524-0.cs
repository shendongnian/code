        public class FetchTiming
        {
            public List<string> show_times { get; set; }
            public string FormattedShowTimes 
            {
                get
                {
                    return string.Join(", ", this.show_times);
                }
            }
        }
