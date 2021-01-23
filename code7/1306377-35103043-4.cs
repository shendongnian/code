	public class Node<T> : LinkedList<Node<T>>
	{
		public T Data { get; set; }
	
		public Node(T data)
		{
			this.Data = data;
		}
	}
