	public class Path : List<Node>
	{
		public override string ToString()
		{
			String s = "";
			foreach (var node in this)
			{
				s += node.Name + node.Links[0] + "->";
			}
			return s;
		}
		public Path Clone()
		{
			var newPath = new Path();
			ForEach(x => newPath.Add(new Node {Name = x.Name, Links = new int[] {x.Links[0]}}));
			return newPath;
		}
	}
		private static List<Path> GetPath(int depth, Path path)
		{
			if (depth == nodes.Length)
			{
				return new List<Path> { path };
			}
			else
			{
				var result = new List<Path>();
				
				foreach (var link in nodes[depth].Links)
				{
					Node node = new Node { Name = nodes[depth].Name, Links = new[] { link } };
					var currentPath = path.Clone();
					currentPath.Add(node);
					result.AddRange(GetPath(depth + 1, currentPath));
				}
				return result;
			}
		}
