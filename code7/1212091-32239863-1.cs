        public class TradeTotal
        {
            public string Trade { get; set; }
            public decimal? Total { get; set; }
        }
        public class JobTrade
        {
            public int JobId { get; set; }
            public List<TradeTotal> TradeTotals { get; set; }
        }
