    class Program
    {
        static void Main(string[] args)
        {
            var doc = new HtmlDocument();
            doc.Load(args[0]);
            var wordCount = 0;
            var nodes = doc.DocumentNode
                           .SelectNodes("/html/body//*[not(self::script)]/text()");
            foreach (var node in nodes)
            {
                var words = node.InnerHtml.Split(' ');
                var surroundedWords = words.Select(word =>
                {
                    if (String.IsNullOrWhiteSpace(word))
                    {
                        return word;
                    }
                    else
                    {
                        return $"<span data-wordno={wordCount++}>{word}</span>";
                    }
                });
                var newInnerHtml = String.Join("", surroundedWords);
                node.InnerHtml = newInnerHtml;
            }
            WriteLine(doc.DocumentNode.InnerHtml);
        }
    }
