    public class Cluster
    {
        public Dictionary<int, List<ClusterMember>> Dic { get; }
            = new Dictionary<int, List<ClusterMember>>();
        // Initialize empty cluster.
        public Cluster()
        {
        }
        // Initialize cluster with one initial member.
        public Cluster(int key, ClusterMember member)
        {
            Add(key, member);
        }
        // Initialize cluster with many members.
        public Cluster(int key, IEnumerable<ClusterMember> members)
        {
            Add(key, members);
        }
        // Allows you to a one new member.
        public void Add(int key, ClusterMember member)
        {
            if (Dic.TryGetValue(key, out var memberList)) {
                memberList.Add(member);
            } else {
                memberList = new List<ClusterMember> { member };
                Dic.Add(key, memberList);
            }
        }
        // Allows you to add many members.
        public void Add(int key, IEnumerable<ClusterMember> members)
        {
            if (Dic.TryGetValue(key, out var memberList)) {
                memberList.AddRange(members);
            } else {
                memberList = new List<ClusterMember>(members);
                Dic.Add(key, memberList);
            }
        }
    }
