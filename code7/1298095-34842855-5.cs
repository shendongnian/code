    public class ExcelManager
    {
        public ExcelManager()
        {
            ItsApplication = null;
            ItsWorkbook = null;
            ItsWorksheet = null;
            AppInitialization = false;
            WrbInitialization = false;
            WrsInitialization = false;
        }
        /*////////////////////////////////////////////////////*/
        public void Initialize(bool visible)
        {
            try
            {
                if (ItsApplication == null)
                {
                    ItsApplication = new Microsoft.Office.Interop.Excel.Application();
                    ItsApplication.SheetsInNewWorkbook = 1;
                    ItsApplication.Visible = visible;
                    AppInitialization = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public void CreateWorkbook()
        {
            try
            {
                if (ApplicationInitialized)
                {
                    ItsWorkbook = ItsApplication.Workbooks.Add(MissingValue);
                    WrbInitialization = true;
                }
                else
                    MessageBox.Show(
                        "Couldnot create workbook!\n" +
                        "App instance didnot initialized!",
                        "Error!!!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public void CreateWorksheet()
        {
            try
            {
                if (WorkbookInitialized)
                {
                    ItsWorksheet = ItsWorkbook.Worksheets.Add(MissingValue,
                        MissingValue, MissingValue, MissingValue);
                    WrsInitialization = true;
                    CurrentRow = 1;
                }
                else
                    MessageBox.Show(
                        "Couldnot create worksheet!\n" +
                        "Workbook didnot created!", 
                        "Error!!!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public void SetText(string text,int bold,int italic,int cells_offset)
        {
            try
            {
                if (WorksheetInitialized)
                {
                    ArrayList lines_list = new ArrayList();
                    string curr_line = "";
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i] == '\n' || (i == text.Length - 1))
                        {
                            lines_list.Add(curr_line);
                            curr_line = "";
                        }
                        curr_line += text[i];
                    }
                    CurrentRow += cells_offset;
                    foreach (object line in lines_list)
                    {
                        Range text_range =
                            ItsWorksheet.get_Range("A" + CurrentRow, "A" + CurrentRow);
                        text_range.Font.Bold = bold;
                        text_range.Font.Italic = italic;
                        text_range.Value2 = line;
                        text_range.WrapText = false;
                        CurrentRow++;
                    }
                }
                else
                    MessageBox.Show(
                        MessageBox.Show(
                        "Cannot output any text!\n" +
                        "Worksheed didnot created!",
                        "Error!!!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public void SetData(System.Data.DataTable table, int bold, int italic,int rows_offset)
        {
            try
            {
                if (WorksheetInitialized)
                {
                    CurrentRow += rows_offset;
                    int TableRows = table.Rows.Count;
                    int TableCols = table.Columns.Count;
                    char ACol = 'A';
                    Range TableRange = ItsWorksheet.get_Range("A" + CurrentRow,
                        ((char)((int)ACol + TableCols - 1)).ToString() + (CurrentRow + TableRows).ToString());
                    TableRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    for (int i = 0; i < TableCols; i++)
                    {
                        Range names_range = ItsWorksheet.get_Range(((char)((int)ACol + i)).ToString() + CurrentRow,
                            ((char)((int)ACol + i)).ToString() + CurrentRow);
                        names_range.Value2 = table.Columns[i].ColumnName;
                    }
                    for (int i = 1; i < TableRows + 1; i++)
                    {
                        for (int j = 0; j < TableCols; j++)
                        {
                            Range cell_range = ItsWorksheet.get_Range(((char)((int)ACol + j)).ToString() + (CurrentRow + i),
                            ((char)((int)ACol + j)).ToString() + (CurrentRow + i));
                            cell_range.Value2 = table.Rows[i - 1].ItemArray[j];
                            cell_range.Font.Bold = bold;
                            cell_range.Font.Italic = italic;
                        }
                    }
                    CurrentRow += TableRows;
                }
                else
                    MessageBox.Show(
                        "Cannot output any text!\n" +
                        "Worksheed didnot created!",
                        "Error!!!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public void SaveCurrentWorksheet(string filename)
        {
            try
            {
                ItsWorksheet.SaveAs(filename,
                    MissingValue,
                    MissingValue,
                    MissingValue,
                    MissingValue,
                    MissingValue,
                    MissingValue,
                    MissingValue,
                    MissingValue,
                    MissingValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public void CloseCurrentWorksheet()
        {
            if (WorkbookInitialized)
            {
                ItsWorkbook.Close(MissingValue,
                    MissingValue,
                    MissingValue);
                ItsApplication.Quit();
                WrbInitialization = false;
                WrsInitialization = false;
                AppInitialization = false;
            }
        }
        public bool ApplicationInitialized
        {
            get
            {
                return AppInitialization;
            }
        }
        public bool WorkbookInitialized
        {
            get
            {
                return WrbInitialization;
            }
        }
        public bool WorksheetInitialized
        {
            get
            {
                return WrsInitialization;
            }
        }
        ////////////////////////////////////////////////////////
        private _Application ItsApplication;
        private _Worksheet ItsWorksheet;
        private _Workbook ItsWorkbook;
        // Initialization flags
        private bool AppInitialization;
        private bool WrbInitialization;
        private bool WrsInitialization;
        // Positioning text in rows
        private int CurrentRow;
        ////////////////////////////////////////////////////////
        // Define static members of class
        private static object MissingValue = System.Reflection.Missing.Value;
        private static object EndOfDocument = "\\endofdoc";
    }
