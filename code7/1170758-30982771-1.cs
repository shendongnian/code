	void Main()
	{
		Tree t = new Tree<string>();  //replace string with your data type in this generic list
		t.Nodes.Add( new Node<string>("1st level"));  //add node to tree
		
		Node<string> nd=t.Nodes[0];  //retrieve node
		nd.Children.Add(new Node<string>("2nd level"));  //add child node to root node 
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
	}
	
	
	
	
	
	//Tree class
	public class Tree<T>  // where T: interface/abstract class your object derives from or the object itself
	{
		public Tree ()
		{
			this.Nodes = new List<Node<T>>();	
		}
		
		public List<Node<T>> Nodes { get; set; }
	}
