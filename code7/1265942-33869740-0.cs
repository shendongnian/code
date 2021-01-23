    class ObjectPersistence
    {
    	public void StoreBSTToFile(BST bst, string TreeStoreFile)
    	{
    		using (var writer = new BinaryWriter(File.Create(TreeStoreFile)))
    			WriteNode(writer, bst.root);
    	}
    	public BST ReadBSTFromFile(string TreeStoreFile)
    	{
    		using (var reader = new BinaryReader(File.OpenRead(TreeStoreFile)))
    			return new BST { root = ReadNode(reader) };
    	}
    	private static void WriteNode(BinaryWriter output, Node node)
    	{
    		if (node == null)
    			output.Write(false);
    		else
    		{
    			output.Write(true);
    			output.Write(node.key);
    			WriteNode(output, node.leftc);
    			WriteNode(output, node.rightc);
    		}
    	}
    	private static Node ReadNode(BinaryReader input)
    	{
    		if (!input.ReadBoolean()) return null;
    		var node = new Node();
    		node.key = input.ReadInt32();
    		node.leftc = ReadNode(input);
    		node.rightc = ReadNode(input);
    		return node;
    	}
    }
