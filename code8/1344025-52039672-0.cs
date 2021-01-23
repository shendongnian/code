    public class Cluster
    {
        public Dictionary<int, List<ClusterMember>> Dic { get; }
            = new Dictionary<int, List<ClusterMember>>();
        public Cluster(int _id, List<ClusterMember> _clusMem)
        {
            Dic.Add(_id, _clusMem);
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
