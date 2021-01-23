    public static class ExcelPivotHelper
    {
        public static void CreateExcelPivot(Stream outputStream, DataTable data, PivotSettings settings)
        {
            using (var pckg = new ExcelPackage())
            {
                var book = pckg.Workbook;
                var pivotSheet = book.Worksheets.Add("Pivot");
                var dataSheet = book.Worksheets.Add("Data");
                var dataRange = GenerateDataSheet(data, dataSheet);
                GeneratePivotSheet(pivotSheet, dataRange, settings);
                pckg.SaveAs(outputStream);
            }
        }
    
        private static void GeneratePivotSheet(ExcelWorksheet pivotSheet, ExcelRangeBase dataRange, PivotSettings settings)
        {
            //var rowCount = data.Rows.Count;
            //var columnCount = data.Columns.Count;
            var pt = pivotSheet.PivotTables.Add(pivotSheet.Cells["A1"], dataRange, "PivotTable");
    
            pt.MultipleFieldFilters = true;
            pt.RowGrandTotals = true;
            pt.ColumGrandTotals = true;
            pt.Compact = true;
            pt.CompactData = true;
            pt.GridDropZones = false;
            pt.Outline = false;
            pt.OutlineData = false;
            pt.ShowError = true;
            pt.ErrorCaption = "[error]";
            pt.ShowHeaders = true;
            pt.UseAutoFormatting = true;
            pt.ApplyWidthHeightFormats = true;
            pt.ShowDrill = true;
            pt.DataOnRows = false;
    
            pt.FirstHeaderRow = 1;  // first row has headers
            pt.FirstDataCol = 1;    // first col of data
            pt.FirstDataRow = 2;    // first row of data
    
            pt.TableStyle = TableStyles.Medium6;
    
            //pt.ColumGrandTotals = true;
            //pt.RowGrandTotals = true;
            //pt.GrandTotalCaption = "Genel Toplam";
    
            // pt.RowHeaderCaption = "";
            foreach (var column in settings.Columns)
            {
                var field = pt.Fields[column.Field];
                var pivotField = pt.ColumnFields.Add(field);
                if (column.PivotDataType == PivotDataType.Date)
                {
                    //pivotField.AddDateGrouping(eDateGroupBy.Days);
                }
            }
    
            foreach (var row in settings.Rows)
            {
                var field = pt.Fields[row.Field];
                var pivotField = pt.RowFields.Add(field);
                if (row.PivotDataType == PivotDataType.Date)
                {
                    //pivotField.AddDateGrouping(eDateGroupBy.Days);
                }
            }
    
            foreach (var measurement in settings.Measurements)
            {
                var field = pt.Fields[measurement.Field];
                var pivotField = pt.DataFields.Add(field);
                pivotField.Format = measurement.DisplayFormat;
                pivotField.Function = DataFieldFunctions.Sum;
                pivotField.Name = measurement.Caption;
            }
            
        }
    
        private static readonly Type[] NumericTypes = { typeof(decimal), typeof(double), typeof(float), typeof(int), typeof(long), typeof(short), typeof(byte) };
        private static ExcelRangeBase GenerateDataSheet(DataTable data, ExcelWorksheet dataSheet)
        {
            dataSheet.Hidden = eWorkSheetHidden.VeryHidden;
            var range = dataSheet.Cells["A1"].LoadFromDataTable(data, true, TableStyles.Medium6);
            range.AutoFitColumns();
            for (var i = 0; i < data.Columns.Count; i++)
            {
                var ix = i + 1;
                var cell = dataSheet.Cells[2, ix, data.Rows.Count + 1, ix];
                var column = data.Columns[i];
                if (NumericTypes.Contains(column.DataType))
                {
                    cell.Style.Numberformat.Format = "#,##0";
                }
                else if (column.DataType == typeof(DateTime))
                {
                    cell.Style.Numberformat.Format = "dd.MM.yyyy";
                }
            }
    
            return range;
        }
    }
    public class PivotSettings
    {
        private string _generalTotalText = "Genel Toplam";
        private string _yesText = "Evet";
        private string _noText = "Hayır";
        private string _fileExtension = ".xlsx";
    
        /// <summary>
        ///     Default ctor
        /// </summary>
        public PivotSettings()
        {
            Columns = new List<PivotItemSetting>(10);
            Rows = new List<PivotItemSetting>(10);
            Measurements = new List<MeasureSetting>(10);
        }
    
        /// <summary>
        /// Column Item Settings
        /// </summary>
        public List<PivotItemSetting> Columns { get; set; }
    
        /// <summary>
        /// Row Item Settings
        /// </summary>
        public List<PivotItemSetting> Rows { get; set; }
    
        /// <summary>
        /// Measure Settings
        /// </summary>
        public List<MeasureSetting> Measurements { get; set; }
    
        /// <summary>
        ///     Display text for 'Genel Toplam' word. Default is 'Genel Toplam'
        /// </summary>
        public string GeneralTotalText
        {
            get { return _generalTotalText; }
            set { _generalTotalText = value; }
        }
    
        /// <summary>
        ///     Display text for 'Evet' word. Default is 'Evet'
        /// </summary>
        public string YesText
        {
            get { return _yesText; }
            set { _yesText = value; }
        }
    
        /// <summary>
        ///     Display text for 'Hayır' word. Default is 'Hayır'
        /// </summary>
        public string NoText
        {
            get { return _noText; }
            set { _noText = value; }
        }
    
        /// <summary>
        ///     Excel File Extension
        /// </summary>
        public string FileExtension
        {
            get { return _fileExtension; }
            set { _fileExtension = value; }
        }
    }
    
    
    /// <summary>
    ///     Setting for Pivot Column and Row
    /// </summary>
    public class PivotItemSetting
    {
        private string _displayFormat = "{0}";
    
        /// <summary>
        ///     Field Name
        /// </summary>
        public string Field { get; set; }
    
        /// <summary>
        ///     Desired data type of the field
        /// </summary>
        public PivotDataType PivotDataType { get; set; }
    
        /// <summary>
        ///     Desired display format string for field
        /// </summary>
        public string DisplayFormat
        {
            get { return _displayFormat; }
            set { _displayFormat = value; }
        }
    
        /// <summary>
        ///     Automatically filled by generation process. Don't fill manually.
        /// </summary>
        public int CalculatedItemCount { get; set; }
    }
    
    /// <summary>
    ///     Pivot Measure Setting
    /// </summary>
    public class MeasureSetting
    {
        private string _displayFormat = "#,##0";
    
        /// <summary>
        ///     Field Name
        /// </summary>
        public string Field { get; set; }
    
        /// <summary>
        ///     Measure Caption
        /// </summary>
        public string Caption { get; set; }
    
        /// <summary>
        ///     Type of Measure
        /// </summary>
        public MeasureType MeasureType { get; set; }
    
        /// <summary>
        ///     Desired display format string for measure
        /// </summary>
        public string DisplayFormat
        {
            get { return _displayFormat; }
            set { _displayFormat = value; }
        }
    }
    
    /// <summary>
    ///     Masure type
    /// </summary>
    public enum MeasureType
    {
        /// <summary>
        ///     Sum of the values for measure field
        /// </summary>
        Sum
    }
