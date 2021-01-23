    public class Hierarchy
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
    }
    public static IList<Hierarchy> GetHierarchy(IList<string> sequenceList)
    {
        int iD = 0;
        List<Hierarchy> hierarchy = new List<Hierarchy>();
        foreach (string sequence in sequenceList.Where(x => x.Count(f => f == '.') == 0)) // get the root nodes
        {
            iD++;
            var item = new Hierarchy() { ID = iD, ParentID = 0 };
            hierarchy.Add(item);
            hierarchy.AddRange(GetChildsRecursive(sequence, item.ID, sequenceList, () => ++iD));
        }
        return (IList<Hierarchy>)hierarchy;
    }
    private static IList<Hierarchy> GetChildsRecursive(string parentSequence, int parentId, IList<string> sequences, Func<int> idGenerator)
    {
        var parentDots = parentSequence.Count(f => f == '.');
        var childSequences = sequences.Where(x => x.StartsWith(parentSequence) && x.Count(f => f == '.') == parentDots + 1);
        var list = new List<Hierarchy>();
        foreach (var childSequence in childSequences)
        {
            var item = new Hierarchy() { ID = idGenerator(), ParentID = parentId };
            list.Add(item);
            list.AddRange(GetChildsRecursive(childSequence, item.ID, sequences, idGenerator));
        }
        return list;
    }
