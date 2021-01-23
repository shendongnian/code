    Document doc = new Document(@"D:\a.docx");
    var builder = new DocumentBuilder(doc);
    var mBuilder = new StringBuilder();
    var paragraphs = builder.Document.GetChildNodes(NodeType.Paragraph, true).ToList();
    paragraphs.ForEach(
    	x =>
    		{
    			((Paragraph)x).Runs.ToArray().ToList().ForEach(y => mBuilder.Append(y.Text));
    			mBuilder.Append(Environment.NewLine);
    		}
    );
    System.IO.File.WriteAllText(@"c:/a.txt", mBuilder.ToString());
    Console.ReadLine();
