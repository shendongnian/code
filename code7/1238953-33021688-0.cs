    public class Hierarchy
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Sequence { get; set; }
    }
    public static IList<Hierarchy> GetHierarchy(IList<string> sequenceList)
    {
        int iD = 0;
        List<Hierarchy> hierarchy = new List<Hierarchy>();
        foreach (string sequence in sequenceList)
        {
            iD++;
            List<string> childSequence = new List<string>();
            string[] sequenceParts = sequence.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            // If the sequence contains sub-sequence, i.e. "2.1" is a sub-sequence of "2".
            if (sequenceParts.Count() > 1)
            {
                var parentSequence = sequence.Substring(0, sequence.LastIndexOf("."));
                var parent = hierarchy.Single(x => x.Sequence == parentSequence);
                hierarchy.Add(new Hierarchy() { ID = iD, ParentID = parent.ID, Sequence = sequence });
            }
            else
                // Add top level.
                hierarchy.Add(new Hierarchy() { ID = iD, ParentID = 0, Sequence = sequence });
        }
        return (IList<Hierarchy>)hierarchy;
    }
