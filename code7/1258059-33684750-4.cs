    private void CopyGridToClipboard(DataGridView grid)
    {
        //Exclude row headers
        grid.RowHeadersVisible = false;
        //Include column headers
        grid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        grid.SelectAll();
        DataObject dataObj = grid.GetClipboardContent();
        if (dataObj != null)
            Clipboard.SetDataObject(dataObj);
        //Set the visibility of row headers back
        grid.RowHeadersVisible = true;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        //Copy grid to clipboard
        this.CopyGridToClipboard(dataGridView1);
        //Open the excel application and add a workbook
        XL.Application application;
        XL.Workbook book;
        XL.Worksheet sheet;
        application = new XL.Application();
        application.Visible = true;
        book = application.Workbooks.Add();
        sheet = (XL.Worksheet)book.Worksheets[1];
        //label1 Text in Cell[1,1]
        ((XL.Range)sheet.Cells[1, 1]).Value = this.label1.Text;
        //textBox1 Text in Cell[1,2]
        ((XL.Range)sheet.Cells[1, 2]).Value = this.textBox1.Text;
        //label2 Text in Cell[2,1]
        ((XL.Range)sheet.Cells[2, 1]).Value = this.label2.Text;
        //textBox2 Text in Cell[2,2]
        ((XL.Range)sheet.Cells[2, 2]).Value = this.textBox2.Text;
        //Let row 3 empty
        //Paste grid into Cell[4,1]
        XL.Range gridRange = (XL.Range)sheet.Cells[4, 1];
        gridRange.Select();
        sheet.PasteSpecial(gridRange);
    }
