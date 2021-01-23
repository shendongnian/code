    public class NodeVM
    {
      public int Id { get; set; }
      public int PartentId { get; set; }
      public string Name { get; set; }
      public IEnumerable<Node> Nodes { get; set; }
      public MvcHtmlString EndTag { get; set; }
    {
    public class TreeVM
    {
      public Stack<Node> Nodes { get; set; }
    }
