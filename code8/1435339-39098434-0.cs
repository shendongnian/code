    public int previousNumber()
    {
        var allLines = File.ReadAllLines("report.txt");
        int pNumber = 0;
        if (allLines.Length > 10 && allLines[allLines.Length - 10] == batchNumberTextBox.Text)
            // Note: if the desired value is "1" and not "4096", then the offset is "-8".
            int.TryParse(allLines[allLines.Length - 8], out pNumber);
        return pNumber + 1;
    }
