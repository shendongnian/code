    public void WriteToFile(StreamWriter file)
    {
        PrintWindow(file);
    }
    public void WriteToConsole()
    {
        PrintWindow(Console.Out);
    }
    public void PrintWindow(TextWriter writer)
    {
        var max = _colLengths.Max();
        for (var rowIndex = 0; rowIndex < max; ++rowIndex)
        {
            for (var colIndex = 0; colIndex < WindowWidth; ++colIndex)
            {
                if (rowIndex < _colLengths[colIndex])
                    writer.Write("{0} ", _actualWindow[colIndex][rowIndex].SymbolName);
                else
                    writer.Write("   ");
            }
            writer.WriteLine();
        }
        writer.WriteLine();
    }
