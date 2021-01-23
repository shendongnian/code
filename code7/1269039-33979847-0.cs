        public static HashSet<string> NetworkIds()
        {
            var result = new HashSet<string>();
            var networkProfiles = Windows.Networking.Connectivity.NetworkInformation.GetConnectionProfiles().ToList();
            foreach (var net in networkProfiles)
            {
                result.Add(net.NetworkAdapter.NetworkAdapterId.ToString());
            }
            return result;
        }
