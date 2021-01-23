        [TestMethod]
        public void CanReadServers()
        {
            var xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + @"
    <Servers>
      <Server>
        <ServerName>STAGING</ServerName>
        <ServerIP>XXX.XXX.XX.X</ServerIP>
      </Server>
    </Servers>";
            IEnumerable<ServerDetails> servers;
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                servers = GetServers(stream).ToList();
            Assert.AreEqual(1, servers.Count());
            Assert.AreEqual("STAGING", servers.ElementAt(0).ServerName);
            Assert.AreEqual("XXX.XXX.XX.X", servers.ElementAt(0).ServerIP);
        }
