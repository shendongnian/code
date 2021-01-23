    class Node {
      public int UniquePartID { get; private set; }
      public int Level { get; private set; }
      public int SubLevel { get; private set; }
      public IList<Node> Children { get; set; }
      public Node Parent { get; set; }
      public Node(int uniquePartID, int level, int subLevel) {
        UniquePartID = uniquePartID;
        Level = level;
        SubLevel = subLevel;
        Children = new List<Node>();
      }
      public override string ToString() {
        return Level.ToString();
      }
    }
