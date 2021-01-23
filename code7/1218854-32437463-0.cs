    class Program
    {
        static void Main(string[] args)
        {
            Application application = new Application();
            Document document = application.Documents.Open("D:\\test.doc");
            if (document.Paragraphs.Count > 0)
            {
                var paragraph = document.Paragraphs.First;
                var lastCharPos = paragraph.Range.Sentences.First.End-1;
                Console.WriteLine(lastCharPos);
            }
            Console.ReadLine();
        }
    }
