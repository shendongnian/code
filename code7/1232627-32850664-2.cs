    List<string> CheckedValues = new List<string>();
    private void button1_Click(object sender, EventArgs e)
    {
        CheckedValues = new List<string> { "value1", "value2", "value5", "value8", "value10", "value11" };
        printDocument1.Print();
    }
    int currentPrintingIndex = 0;
    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        //Width of output labels
        var d= this.printDocument1.DefaultPageSettings.PrintableArea.Width / 2;
        if (CheckedValues.Count > currentPrintingIndex)
        {
            var currentValue = CheckedValues[currentPrintingIndex];
            e.Graphics.DrawString(currentValue.ToString(),
                        this.Font,
                        new SolidBrush(this.ForeColor),
                        new RectangleF(
                            0,
                            0,
                            d,
                            this.printDocument1.DefaultPageSettings.PrintableArea.Height));
            currentPrintingIndex += 1;
        }
        if (CheckedValues.Count > currentPrintingIndex)
        {
            var currentValue = CheckedValues[currentPrintingIndex];
            e.Graphics.DrawString(currentValue.ToString(),
                        this.Font,
                        new SolidBrush(this.ForeColor),
                        new RectangleF(
                            d,
                            0,
                            d,
                            this.printDocument1.DefaultPageSettings.PrintableArea.Height));
            currentPrintingIndex += 1;
        }
        e.HasMorePages = CheckedValues.Count > currentPrintingIndex;
    }
