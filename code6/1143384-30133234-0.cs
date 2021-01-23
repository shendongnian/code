    public class Node
    {
      public int Id { get; set; }
      public int ParentId { get; set; }
      public IEnumerable<Node> Nodes { get; set; }
      public Node ParentNode { get; set; }
    }
    IEnumerable<Node> nodes = .....
    nodeTree = nodes.Select(n =>
    {
      n.Nodes = nodes.Where(n2 => n2.ParentId == n.Id).ToList();
      n.ParentNode = nodes.FirstOrDefault(n2 => n2.Id == n.ParentId)
      return n;
    })
    .Where(n => n.ParentNode == null)
    .ToList();
