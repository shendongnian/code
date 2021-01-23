	public class Program
	{
		public static void Main()
		{
			List<Vector3> results = new List<Vector3>();
			using (var file = System.IO.File.OpenText(@"C:\temp\test.txt"))
			{
				string line;
				while ((line = file.ReadLine()?.Trim()) != null)
				{
					// skip empty lines and comments
					if (line == string.Empty || line.StartsWith("//"))
						continue;
					// parse all other lines as vectors, exit program on error
					try
					{
						Vector3 vector = ParseVector(line);
						results.Add(vector);
					}
					catch (FormatException e)
					{
						Console.WriteLine("Parse error on line: {0}", line);
						throw;
					}
				}
			}
			
			foreach (var v in results)
				Console.WriteLine("({0},{1},{2})", v.X, v.Y, v.Z);
		}
		
		// parse string in format '(x,y,z)', all as floats
		// throws FormatException on any error
		public static Vector3 ParseVector(string text)
		{
			if (!text.StartsWith("(") || !text.EndsWith(")"))
				throw new FormatException();
			string[] parts = text.Substring(1, text.Length - 1).Split(',');
			if (parts.Length != 3)
				throw new FormatException();
			float x = float.Parse(parts[0]);
			float y = float.Parse(parts[1]);
			float z = float.Parse(parts[2]);
			return new Vector3(x, y, z);
		}
	}
