    using Newtonsoft.Json;
    
    public class XenNode
    {
    	public int count { get; set; }
    	[JsonConverter(typeof(NodesConverter))]
    	public Node[] Nodes { get; set; }
    }
    public class Node
    {
    	public int node_number { get; set; }
    	public int node_id { get; set; }
    	public string title { get; set; }
    	public string description { get; set; }
    	public string node_name { get; set; }
    	public string node_type_id { get; set; }
    	public int parent_node_id { get; set; }
    	public int display_order { get; set; }
    	public int display_in_list { get; set; }
    	public int lft { get; set; }
    	public int rgt { get; set; }
    	public int depth { get; set; }
    	public int style_id { get; set; }
    	public int effective_style_id { get; set; }
    }
    
    // Deserialize
    XenNode xenNode = JsonConvert.DeserializeObject<XenNode>(json);
