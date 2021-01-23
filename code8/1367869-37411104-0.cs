    public static class SetExtensions {
        public static TValue GetExistingOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> set, TKey key, TValue value) {
            TValue existing;
            if (set.TryGetValue(key, out existing)) {
                return existing;
            }
            set.Add(key, value);
            return value;
        }
    }
    class Program {
        static void Main(string[] args) {
            Stream inputStream = new MemoryStream();
            using (var sw = new StreamWriter(inputStream,  Encoding.UTF8, 4096, true)) {
                sw.WriteLine("Home,      Away,       Referee");
                sw.WriteLine("Leeds,     Leicester,  Steve Dunn");
                sw.WriteLine("Derby,     Everton,    Steve Dunn");
                sw.WriteLine("Leicester, Man United, Andy Hall");
                sw.WriteLine("Everton,   Leicester,  Andy Hall");
            }
            inputStream.Position = 0;
            TextReader reader = new StreamReader(inputStream);
            var csv = new CsvReader(reader);
            csv.Configuration.TrimFields = true;
            csv.Configuration.TrimHeaders = true;
            csv.Configuration.RegisterClassMap<GameMap>(); //You only need to register the "root" map
            var referees = new Dictionary<string, Referee>(); //Stores unique referees. You can use the full Referee object as a key if you implement IEquatable<Referee> for Referee
            var teams = new Dictionary<string, Team>();
            var records = new List<Game>();
            while (csv.Read()) {
                var record = csv.GetRecord<Game>();
                record.Referee = referees.GetExistingOrAdd(record.Referee.Name, record.Referee); //Try to link to existing object
                record.HomeTeam = teams.GetExistingOrAdd(record.HomeTeam.Name, record.HomeTeam); //Try to link to existing object
                record.AwayTeam = teams.GetExistingOrAdd(record.AwayTeam.Name, record.AwayTeam); //Try to link to existing object
                records.Add(record);
            }
        }
