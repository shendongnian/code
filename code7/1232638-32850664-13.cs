    private int currentPrintingIndex = 0;       
    List<string> CheckedValues = new List<string>();
    
    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        //Barcode Font
        Font fbarra = new Font("IDAutomationSC128S", 10, FontStyle.Regular, GraphicsUnit.Pixel);
    
        IEnumerable<DataGridViewRow> CheckedValues = this.dgv1.Rows.Cast<DataGridViewRow>()
        .Where(row => (bool?)row.Cells[0].Value == true)
        .Skip(currentPrintingIndex);
    
        IEnumerator<DataGridViewRow> cve = CheckedValues.GetEnumerator();
        int count = 0;
        int pos = 60;
    
        while ((e.HasMorePages = cve.MoveNext()) && count++ < 2)
        {
            var cellValues = cve.Current.Cells.Cast<DataGridViewCell>()
                        .Skip(1)    //instead of .Where(cell => cell.ColumnIndex > 0)
                        .Select(cell => cell.Value.ToString())
                        .ToArray();
    
    
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Join(",", cellValues));
    
            string fullline = builder.ToString();
            string[] column1 = fullline.Split(',');
    
            var cents = column1[3].Substring(0, 2);
            var descr = column1[1].ToString();
            var descr2 = descr.Substring(0, 30);
            var descr3 = descr.Substring(30);
    
            var encodeddata1 = Encode.Code128(column1[0].ToString(), 0, false);
            var number = encodeddata1;
    
            //draw barcode
            e.Graphics.DrawString(number, fbarra, Brushes.Black, pos, 105);
            currentPrintingIndex += 1;
    
            pos += 150;
        }
    }
