    using (StreamReader sr = new StreamReader("SampleInput.txt"))
    {
        string line = string.Empty;
        while ((line = sr.ReadLine()) != null)
        {
            rbResult.Document.Blocks.Add(new Paragraph(new Run(line)));
        }
    }
        
