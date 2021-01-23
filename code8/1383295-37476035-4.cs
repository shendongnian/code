        public IEnumerable<ServerDetails> GetServers(string file)
        {
            using (var stream = File.Open(file, FileMode.Open, FileAccess.Read))
                return GetServers(stream);
        }
        public IEnumerable<ServerDetails> GetServers(Stream stream)
        {
            var root = XElement.Load(stream);
            return GetServers(root);
        }
        public IEnumerable<ServerDetails> GetServers(XElement root)
        {
            foreach (var server in root.Elements("Server"))
            {
                yield return new ServerDetails
                {
                    ServerName = (string)server.Element("ServerName"),
                    ServerIP = (string)server.Element("ServerIP"),
                };
            }
        }
