    /// <summary>
    ///     Settings for Pivot Table
    /// </summary>
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
    /// <summary>
    ///     Pivot Item type 
    /// </summary>
    public enum PivotDataType
    {
        /// <summary>
        ///     Not Defined, Default
        /// </summary>
        None,
        /// <summary>
        ///     String
        /// </summary>
        String,
        /// <summary>
        /// Date Part of DateTime
        /// </summary>
        Date,
        /// <summary>
        /// DateTime
        /// </summary>
        DateTime,
        /// <summary>
        /// Numeric
        /// </summary>
        Numeric,
        /// <summary>
        /// Boolean
        /// </summary>
        Boolean
    }
