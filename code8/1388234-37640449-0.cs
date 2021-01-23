    class Program
    {
        static void Main(string[] args)
        {
            var now = DateTime.Now;
            var ff = now.ToEorzeaTime();
            Console.WriteLine($"Now: {now} | FF: {ff}");
            var ffNew = new DateTime(ff.Ticks, DateTimeKind.Utc);
            var nowNew = ffNew.ToEarthTime();
            Console.WriteLine($"Now: {nowNew} | FF: {ffNew}");
            Console.ReadLine();
        }
    }
    public static class Converter
    {
        private const double EORZEA_MULTIPLIER = 3600D / 175D;
        public static DateTime ToEorzeaTime(this DateTime date)
        {
            long epochTicks = date.ToUniversalTime().Ticks - (new DateTime(1970, 1, 1).Ticks);
            long eorzeaTicks = (long)Math.Round(epochTicks * EORZEA_MULTIPLIER);
            return new DateTime(eorzeaTicks);
        }
        public static DateTime ToEarthTime(this DateTime date)
        {
            var epochTicks = (long) Math.Round(date.Ticks/EORZEA_MULTIPLIER);
            var earthTicks = epochTicks + new DateTime(1970, 1, 1).Ticks;
            var utc = new DateTime(earthTicks, DateTimeKind.Utc);
            return utc.ToLocalTime();
        }
    }
