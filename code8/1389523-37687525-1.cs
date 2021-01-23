       private void printDocDetail_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;
            Pen blackPen = new Pen(Color.Black, 1);
        // Create points that define line.
        Font font = new Font("Courier New", 8); //must use a mono spaced font as the spaces need to line up
        Font titleFont = new Font("Courier New", 8, FontStyle.Bold);
        float fontHeight = font.GetHeight();
        int startX = 10;
        int startY = 10;
        int offset = 40;
        DataGridViewRow row = rows.SharedRow(page);
        EditContact contact = new EditContact(row.Cells[4].Value.ToString());
        // same code to print as initial question inserted here
        page++;
        e.HasMorePages = (page < rows.Count) ? true : false;
        
    }
