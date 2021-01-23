        public static List<string> FindComPorts()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0"))
            {
                return searcher.Get().OfType<ManagementBaseObject>()
                    .Select(port => Regex.Match(port["Caption"].ToString(), @"\((COM\d*)\)"))
                    .Where(match => match.Groups.Count >= 2)
                    .Select(match => match.Groups[1].Value).ToList();
            }
        }
