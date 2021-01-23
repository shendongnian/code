    public void OnMessage(QuickFix.FIX42.MarketDataIncrementalRefresh message, SessionID sessionID)
    {
        this.marketDataIncrementalRefreshHandler.Handle(message);
    }
    public void OnMessage(QuickFix.FIX44.MarketDataIncrementalRefresh message, SessionID sessionID)
    {
        this.marketDataIncrementalRefreshHandler.Handle(message);
    }
    ... elsewhere ...
    public interface FixMessageHandler
    {
        void Handle(Message msg);
    }
    public class MarketDataIncrementalRefreshHandler : FixMessageHandler
    {
        public void Handle(Message msg)
        {
            DateTime sourceDT = DateTime.ParseExact(message.Header.GetField(52), "yyyyMMdd-HH:mm:ss.fff", ci);
            DateTime dt = TimeZoneInfo.ConvertTimeToUtc(sourceDT, utcZone);
            DateTime nowUTC = TimeZoneInfo.ConvertTime(DateTime.UtcNow, utcZone, utcZone);
            TimeSpan diffToUK = nowUTC - dt;
            var noMDEntriesGroups = this.GetAllNoMDEntries(msg)
            foreach (var noMDEntriesGroup in noMDEntriesGroups)
            {
                masterForm.MDATA.AddData(
                    noMDEntriesGroup.Symbol,
                    noMDEntriesGroup.TickBandNoDecPlaces,
                    sourceDT);
            }
        }
        private IEnumerable<NoMDEntriesGroup> GetAllNoMDEntries(Message msg)
        {
            switch (message.GetString(8)) // BeginString
            {
                case Values.BeginString_FIX42:
                    return this.GetAllNoMDEntries((QuickFix.FIX42.MarketDataSnapshotFullRefresh)msg);
                case Values.BeginString_FIX44:
                    return this.GetAllNoMDEntries((QuickFix.FIX44.MarketDataSnapshotFullRefresh)msg);
                default:
                    throw new NotSupportedException("This version of FIX is unsupported");
            }
        }
        private IEnumerable<NoMDEntriesGroup> GetAllNoMDEntries(QuickFix.FIX42.MarketDataSnapshotFullRefresh msg)
        {
            int count = message.NoMDEntries.getValue();
            QuickFix.FIX42.MarketDataSnapshotFullRefresh.NoMDEntriesGroup repeatingMDItem = new QuickFix.FIX42.MarketDataSnapshotFullRefresh.NoMDEntriesGroup();
            for (int i = 1; i <= count; i++)
            {
                message.GetGroup(i, repeatingMDItem);
                yield return new NoMDEntriesGroup
                {
                    Symbol = repeatingMDItem.GetField(55),
                    TickBandNoDecPlaces = int.Parse(repeatingMDItem.GetField(5071)
                };
            }
        }
        private IEnumerable<NoMDEntriesGroup> GetAllNoMDEntries(QuickFix.FIX44.MarketDataSnapshotFullRefresh msg)
        {
            // Should be practically identical to the above version, with 4.4 subbed for 4.2
        }
        private class NoMDEntriesGroup
        {
            public string Symbol { get; set; }
            public int TickBandNoDecPlaces { get; set; }
        }
    }
