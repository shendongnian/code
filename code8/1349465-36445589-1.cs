    using (var sr = new System.IO.StreamReader(filePath))
    {
        var linesBuffer = new List<string>();
        while (sr.Peek() >= 0)
        {
            linesBuffer.Add(sr.ReadLine());
            if (linesBuffer.Count > yourThreshold)
            {
                // TODO: implement function WriteLinesToPartialCsv
                WriteLinesToPartialCsv(linesBuffer);
                // Clear the buffer:
                linesBuffer.Clear();
                // Try forcing c# to clear the memory:
                GC.Collect();
            }
        }
    }
