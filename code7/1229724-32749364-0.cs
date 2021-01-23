    class Letter
    {
        public const char FieldSeparator = ';';
        public const char TimeFieldSeparator = ':'; //WARNING: Tweaking this will result in you needing to change .ToString() calls on TimeSpan and DateTime manually
        public DateTime SendDate { get; private set; }
        public DateTime EstimatedReceivedDate => SendDate + (Server != null ? TimeSpan.FromSeconds((double)Size / Server.TransferRate) : TimeSpan.MaxValue);
        //Traditionally, the server would record this data when it receives it
        public string Sender { get; private set; } //These should be fundamental User / Account classes
        public string Receiver { get; private set; }
        public Server Server { get; private set; }
        public int Size { get; private set; } //We assume this is the size in bytes
        public Letter(DateTime sendDate, string sender, string receiver, Server server, int size)
        {
            SendDate = sendDate;
            Sender = sender;
            Receiver = receiver;
            Server = server;
            Size = size;
        }
        public static Letter Deserialize(string s, IList<Server> servers)
        {
            if (string.IsNullOrEmpty(s)) throw new ArgumentException("Invalid argument s: Cannot parse from null or empty string");
            var split = s.Split(FieldSeparator);
            if (split.Length != 5) throw new ArgumentException("Malformed string s! Format: Time " + FieldSeparator + "Sender" + FieldSeparator + "Receiver" + FieldSeparator + "Server" + FieldSeparator + "Size");
            var date = DateTime.Today;
            var timeSplit = split[0].Split(TimeFieldSeparator);
            if (timeSplit.Length != 3) throw new ArgumentException("Malformed time in s! Format: HH" + TimeFieldSeparator + "mm" + TimeFieldSeparator + "ss");
            int hour;
            if (!int.TryParse(timeSplit[0], out hour)) throw new ArgumentException("Could not parse hour from string: " + timeSplit[0]);
            int minute;
            if (!int.TryParse(timeSplit[1], out minute)) throw new ArgumentException("Could not parse minute from string: " + timeSplit[1]);
            int second;
            if (!int.TryParse(timeSplit[2], out second)) throw new ArgumentException("Could not parse second from string: " + timeSplit[2]);
            date = date + new TimeSpan(0, hour, minute, second);
            if (servers == null || servers.Count == 0) throw new ArgumentException("Invalid list of servers passed. No servers mean no message could have been sent.");
            Server server;
            try
            {
                server = servers.First(serv => serv.Name == split[3]);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("Could not parse server from string: " + split[3] + ". No such server was present in the list passed to the function.");
            }
            int size;
            if (!int.TryParse(split[4], out size)) throw new ArgumentException("Could not parse size from string: " + split[4]);
            var letter = new Letter(date, split[1], split[2], server, size);
            server.Letters.Add(letter);
            return letter;
        }
        public string Serialize(Server s)
        {
            return s.ToString();
        }
        public override string ToString()
        {
            return SendDate.ToString("HH:mm:ss") + FieldSeparator + Sender + FieldSeparator + Receiver + FieldSeparator + Server.Name + FieldSeparator + Size;
        }
    }
    class Server
    {
        public const char FieldSeparator = ';';
        public string Name { get; private set; }
        public int TransferRate { get; set; } //Bytes/Sec
        public IList<Letter> Letters { get; private set; }
        public int BytesReceived => Letters.Sum(l => l.Size);
        public int TotalTransferTime => BytesReceived/TransferRate; 
        //Optionally use public int BytesReceived { get { return Letters.Sum(l => l.Size); } } if C# < 6, this applies to all of these
        public DateTime LastLetterReceiveDate => Letters.Max(letter => letter.EstimatedReceivedDate > DateTime.Now ? DateTime.MinValue : letter.EstimatedReceivedDate);
        public Server(string name, int transferRate, IList<Letter> letters)
        {
            Name = name;
            TransferRate = transferRate;
            Letters = letters;
        }
        public Server(string name, int transferRate, params Letter[] letters)
        {
            Name = name;
            TransferRate = transferRate;
            Letters = new List<Letter>(letters.Length);
            foreach (var letter in letters)
                Letters.Add(letter);
        }
        public static Server Deserialize(string s)
        {
            if (string.IsNullOrEmpty(s)) throw new ArgumentException("Invalid argument s: Cannot parse from null or empty string");
            var split = s.Split(FieldSeparator);
            if (split.Length != 2) throw new ArgumentException("Malformed string s! Format: Name " + FieldSeparator + "TransferRate");
            int transferRate;
            if (!int.TryParse(split[1], out transferRate)) throw new ArgumentException("Could not parse transfer rate from string: " + split[1]);
            return new Server(split[0], transferRate);
        }
        public string Serialize(Server s)
        {
            return s.ToString();
        }
        public override string ToString()
        {
            return Name + FieldSeparator + TransferRate;
        }
        public string Summary()
        {
            return Name + FieldSeparator + Letters.Count + FieldSeparator + BytesReceived + FieldSeparator + TotalTransferTime + FieldSeparator + (DateTime.Now - LastLetterReceiveDate).ToString("hh:mm:ss");
        }
    }
    class Program
    {
        public static char EntrySeparator = ' ';
        static void Main(string[] args)
        {
            
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "servers.scv"))) throw new FileNotFoundException("Cannot find file servers.scv file at path" + Path.Combine(Environment.CurrentDirectory, "servers.scv"));
            var serversscv = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "servers.scv"));
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "letters.csv"))) throw new FileNotFoundException("Cannot find file servers.scv file at path" + Path.Combine(Environment.CurrentDirectory, "servers.scv"));
            var letterscsv = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "servers.scv"));
            var serversSplit = serversscv.Split(EntrySeparator);
            var lettersSplit = letterscsv.Split(EntrySeparator);
            var servers = new List<Server>(serversSplit.Length);
            var letters = new List<Letter>(lettersSplit.Length);
            servers.AddRange(serversSplit.Select(Server.Deserialize));
            letters.AddRange(lettersSplit.Select(letterString => Letter.Deserialize(letterString, servers)));
            var oldServers = servers.Where(server => (DateTime.Now - server.LastLetterReceiveDate).TotalHours >= 1).Aggregate(string.Empty, (current, oldServer) => current + oldServer);
            var file = File.CreateText(Path.Combine(Environment.CurrentDirectory, "oldservers.csv"));
            file.WriteLine(oldServers); //Async possible if you're doing a continouous process (ie server does this parsing)
        }
    }
