        public object alarmSummary { get; set; }
        protected string[] alarmSummaryCasted
        {
            get
            {
                if (alarmSummary is String)
                    return null;
                else
                    return (string[]) alarmSummary;
            }
        }
