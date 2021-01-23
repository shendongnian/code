	namespace ConsoleApplication5
	{
		public class DocConfig
		{
			public string Description { get; set; }
			public List<DocPart> Parts;
		}
		public class DocPart
		{
			public string Title { get; set; }
			public string TexLine { get; set; }
		}
		public class Program
		{
			public static int Main()
			{
				List<DocPart> Parts = new List<DocPart>();
				var doc = new DocConfig();
				doc.Description = "bla bla";
				doc.Parts = new List<DocPart>();
				doc.Parts.Add(new DocPart { Title = "aaa", TexLine = @"\include{aaa.tex}" });
				doc.Parts.Add(new DocPart { Title = "bbb ", TexLine = @"\include{bbb.tex}" });
				foreach (DocPart part in doc.Parts)
				{
					Console.WriteLine(part.Title);
				}
				Console.ReadKey();
				return -1;
			}
		}
	}
