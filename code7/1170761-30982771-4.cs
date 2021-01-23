	void Main()
	{
		Tree t = new Tree<string>();  //replace string with your data type in this generic list
		
		//individually
		Node<string> nd1=t.AddNode("level 1");
		Node<string> nd2=nd1.AddNode("level 2");
		Node<string> nd3=nd2.AddNode("level 3");
		
		//in a loop
		var lst = new List<string>{"Level 1", "Level 2", "Level 3"};
		Node<string> parent=null;
		foreach (var itm in lst)
		{
			Node<string> nd=null;
			if (parent==null)
				nd=t.AddNode(itm);  //add as a root node in the tree
			else 
				nd=parent.AddNode(itm); //add as a child node to the parent node
			parent=nd;
		}
		
				
		//process all nodes
		foreach (var node in t.Nodes)
		{
			ProcessNode(node);
		}
	}
	
	//processes each node and it children in using recursive call
	void ProcessNode(Node<string> node)
	{
		System.Console.WriteLine(node.Value); //process current node (print)
		if (node.Children.Count>0)  //process child nodes
		{
			foreach (var nd in node.Children)
			{
				ProcessNode(nd); // recursive call to process child node
			}
		}
	}
	
	
	//tree node class
	public class Node<T>  // where T: interface/abstract class your object derives from or the object itself
	{
		public Node ()
		{
			this.Children=new List<Node<T>>();
		}
		public Node (T val) : this()
		{
			this.Value=val;
		}
	
		public T Value { get; set; }
		public List<Node<T>> Children { get; set; }
		public Node<T> this[int i] {
			get{ return this.Children[i]; }
			set{ this.Children[i]=value;}
		}
		//add a child node to a parent node and return the child
		public Node<T> AddNode(Node<T> parent, T val)
		{
			Node<T> child= new Node<T>(val);
			parent.Children.Add(child);
			return child;
		}
	}
	
	
	
	
	
	//Tree class
	public class Tree<T>  // where T: interface/abstract class your object derives from or the object itself
	{
		public Tree ()
		{
			this.Nodes = new List<Node<T>>();	
		}
		
		public List<Node<T>> Nodes { get; set; }
		
        public Node<T> AddNode(T val)
		{
			Node<T> child= new Node<T>(val);
			this.Nodes.Add(child);
			return child;
		}	
	}
