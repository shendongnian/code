    foreach (var run in doc.Descendants<Run>())
    {
        Console.WriteLine("Run!");
        foreach (var textElement in run.Descendants<Text>())
        {
            string text = textElement.Text;
            Console.WriteLine("- {0}", text.Substring(0, Math.Min(5, text.Length)));
        }
    }
