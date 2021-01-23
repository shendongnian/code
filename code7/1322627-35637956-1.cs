    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Tests
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var list = new LinkedList<int>();
    			for (int n = 1; n <= 8; n++)
    				list.Add(n);
    			Action<string> dump = info => Console.WriteLine("{0,-10}({1})", info, string.Join(",", list.Nodes.Select(n => n.data.ToString())));
    			dump("Input");
    			var random = new Random();
    			for (int i = 1; i <= 10; i++)
    			{
    				list.Shuffle(random);
    				dump("Output " + i);
    			}
    			Console.ReadLine();
    		}
    	}
    
    	public class LinkedList<T>
    	{
    		public class Node
    		{
    			public T data;
    			public Node next;
    		}
    
    		private Node _lastNode;
    		private Node _headNode;
    		private int _count;
    
    		public void Add(T data)
    		{
    			var node = new Node { data = data };
    			if (_lastNode != null) _lastNode.next = node; else _headNode = node;
    			_lastNode = node;
    			_count++;
    		}
    
    		public IEnumerable<Node> Nodes { get { for (var node = _headNode; node != null; node = node.next) yield return node; } }
    
    		public void Shuffle(Random random = null)
    		{
    			if (_count < 2) return;
    			if (random == null) random = new Random();
    			var result = new Node[_count];
    			int i = 0;
    			for (var node = _headNode; node != null; node = node.next)
    			{
    				int j = random.Next(i + 1);
    				if (i != j)
    					result[i] = result[j];
    				result[j] = node;
    				i++;
    			}
    			_headNode = _lastNode = result[0];
    			for (i = 1; i < result.Length; i++)
    				_lastNode = _lastNode.next = result[i];
    			_lastNode.next = null;
    		}
    	}
    }
