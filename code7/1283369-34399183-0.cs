    public class Node
    {
        public string Group { get; set; }
        public int SequenceNumber { get; set; }
        public override string ToString()
        {
            return string.Format("This is the Node.ToString() method!");
        }
    }
    [TestMethod]
    public void Test()
    {
        var unsortedNodes = new List<Node>()
        {
            new Node { Group = "A", SequenceNumber = 1 },
            new Node { Group = "A", SequenceNumber = 2 },
            new Node { Group = "A", SequenceNumber = 3 },
            new Node { Group = "B", SequenceNumber = 11 },
            new Node { Group = "B", SequenceNumber = 12 },
            new Node { Group = "C", SequenceNumber = 20 },
        };
        var query = unsortedNodes.OrderBy(n => n.Group).GroupBy(n => n.Group).SelectMany(g => g.OrderBy(n => n.SequenceNumber));
        var _nodes = query.ToList();
        Assert.IsTrue(_nodes.ToList().All(n => n.ToString() == "This is the Node.ToString() method!"));
    }
