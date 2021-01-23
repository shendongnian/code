    public class MostPlayedList : IEnumerable<YourCommonInteface>
    {
        public IList<MostPlayed> mostPlayed = new List<MostPlayed>();
        public IList<SongNominator> songNominator = new List<SongNominator>();
        public IList<MostUpvoted> songsUpvoted = new List<MostUpvoted>();
        public IList<MostUpvoting> userUpvoting = new List<MostUpvoting>();
        public IEnumerator<YourCommonInteface> GetEnumerator()
        {
            return mostPlayed.Concat(songNominator).Concat(songsUpvoted).Concat();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
