        static void Main(string[] args)
        {
            var clusterMembership = new Dictionary<int, int>();
            //Add cluster 123 and assign a member count of 4
            clusterMembership.Add(123, 4);
            //Change member count for cluster 123 to 5
            clusterMembership[123] = 5;
            //Remove cluster 123
            clusterMembership.Remove(123);
            //Get the number of clusters in the dictionary
            var count = clusterMembership.Count;
            //Iterate through the dictionary
            foreach(var clusterKey in clusterMembership.Keys)
            {
                var memberCount = clusterMembership[clusterKey];
            }
        }
