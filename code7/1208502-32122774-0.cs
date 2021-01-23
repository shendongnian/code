    public void ConcatStreams(TextReader left, TextReader right, TextWriter output, string separator = " ")
    {
        while (true)
        {
            string leftLine = left.ReadLine();
            string rightLine = right.ReadLine();
            if (leftLine == null && rightLine == null)
                return;
            output.Write((leftLine ?? ""));
            output.Write(separator);
            output.WriteLine((rightLine ?? ""));
        }
    }
