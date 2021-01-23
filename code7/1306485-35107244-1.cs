    public class Trie
    {
       //for integer representation in binary system 2^32
    	public static readonly int MaxLengthOfBits = 32;
    	//alphabet trie size
    	public static readonly int N = 2;
    
    	class Node
    	{
    		public Node[] next = new Node[Trie.N];
    	}
    
    	private Node _root;
    }
    
    public void AddValue(bool[] binaryNumber)
    {
    	_root = AddValue(_root, binaryNumber, 0);
    }
    
    private Node AddValue(Node node, bool[] val, int d)
    {
    	if (node == null) node = new Node();
    	
        //if least sagnificient bit has been added
        //need return
        if (d == val.Length)
        {   
    		return node;
        }
    	
        // get 0 or 1 index of next array(length 2)
        int index = Convert.ToInt32(val[d]); 
        node.next[index] = AddValue(node.next[index], val, ++d);
        return node;
    }
