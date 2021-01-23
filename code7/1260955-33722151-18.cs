    internal class AvailableYear
    {
        private readonly int[] _available;
        private static readonly Regex MatchTrue = new Regex("[^0]+");
        private static readonly Dictionary<string, string> GetName = new Dictionary<string, string>
        {
            {"1","Jan" },
            {"2","Feb" },
            {"3","Mar" },
            {"4","Apr" },
            {"5","May" },
            {"6","Jun" },
            {"7","Jul" },
            {"8","Aug" },
            {"9","Sep" },
            {"a","Oct" },
            {"b","Nov" },
            {"c","Dec" },
        };
        public AvailableYear(params int[] available)
        {
            if (available.Length > 12) throw new IndexOutOfRangeException("given parameters should not exceed 12 months.");
            _available = available;
        }
        public int AvaialableJan
        {
            get { return _available[0]; }
            set { _available[0] = value; }
        }
        public int AvailableFeb
        {
            get { return _available[1]; }
            set { _available[1] = value; }
        }
        public int AvailableMar
        {
            get { return _available[2]; }
            set { _available[2] = value; }
        }
        public int AvailableApr
        {
            get { return _available[3]; }
            set { _available[3] = value; }
        }
        public int AvaialableMay
        {
            get { return _available[4]; }
            set { _available[4] = value; }
        }
        public int AvaialableJun
        {
            get { return _available[5]; }
            set { _available[5] = value; }
        }
        public int AvaialableJul
        {
            get { return _available[6]; }
            set { _available[6] = value; }
        }
        public int AvaialableAug
        {
            get { return _available[7]; }
            set { _available[7] = value; }
        }
        public int AvaialableSep
        {
            get { return _available[8]; }
            set { _available[8] = value; }
        }
        public int AvaialableOct
        {
            get { return _available[9]; }
            set { _available[9] = value; }
        }
        public int AvaialableNov
        {
            get { return _available[10]; }
            set { _available[10] = value; }
        }
        public int AvaialableDec
        {
            get { return _available[11]; }
            set { _available[11] = value; }
        }
        public override string ToString()
        {
            string values = string.Join("", _available.Select((x, i) => x == 0 ? "0" : Convert.ToString(i + 1, 16)));
            var matches = MatchTrue.Matches(values).Cast<Match>().Select(x => x.Value).ToList();
            if (matches.Count == 0)
            {
                return "None";
            }
            if (matches[0].Length == 12)
            {
                return "Year round";
            }
            if (matches.Count == 1 && matches[0].Length == 1)
            {
                return GetName[matches[0]] + " Only";
            }
            else
            {
                if (matches.First().StartsWith("1") && matches.Last().EndsWith("c"))
                {
                    matches[0] = matches.Last() + matches.First();
                    matches.RemoveAt(matches.Count - 1);
                }
                List<string> output = new List<string>();
                foreach (var match in matches)
                {
                    if (match.Length == 1)
                    {
                        output.Add(GetName[match]);
                    }
                    else
                    {
                        output.Add(GetName[match.First().ToString()] + "-" +
                                   GetName[match.Last().ToString()]);
                    }
                }
                return string.Join(", ", output);
            }
        }
    }
