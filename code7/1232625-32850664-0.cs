    List<string> CheckedValues = new List<string>();
    private void button1_Click(object sender, EventArgs e)
    {
        CheckedValues = new List<string> { "value1", "value2", "value5", "value8", "value10", "value11" };
        printDocument1.Print();
    }
    int currentPrintingIndex = 0;
    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        if (CheckedValues.Count > currentPrintingIndex)
        {
            var currentValue = CheckedValues[currentPrintingIndex];
            e.Graphics.DrawString(currentValue.ToString(),
                        this.Font,
                        new SolidBrush(this.ForeColor),
                        new RectangleF(
                            0,
                            0,
                            this.printDocument1.DefaultPageSettings.PrintableArea.Width / 2,
                            this.printDocument1.DefaultPageSettings.PrintableArea.Height / 2));
            currentPrintingIndex += 1;
        }
        if (CheckedValues.Count > currentPrintingIndex)
        {
            var currentValue = CheckedValues[currentPrintingIndex];
            e.Graphics.DrawString(currentValue.ToString(),
                        this.Font,
                        new SolidBrush(this.ForeColor),
                        new RectangleF(
                            this.printDocument1.DefaultPageSettings.PrintableArea.Width / 2,
                            0,
                            this.printDocument1.DefaultPageSettings.PrintableArea.Width / 2,
                            this.printDocument1.DefaultPageSettings.PrintableArea.Height / 2));
            currentPrintingIndex += 1;
        }
        e.HasMorePages = CheckedValues.Count > currentPrintingIndex;
    }
