     public partial class Form1 : Form
    {
        public DataTable dt;
        public Form1()
        {
            InitializeComponent();
            dt = new DataTable("TestTable");
            dt.Columns.Add("Duration", typeof(TimeSpan));
            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { new TimeSpan(1, 1, 1, 1) };
            dt.Rows.Add(dr);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["Duration"].DefaultCellStyle.Format = "l";
            
            this.dataGridView1.Columns["Duration"].DefaultCellStyle.FormatProvider = new TimeSpanFormatter();
            this.dataGridView1.DataError += DataGridView1_DataError;
            this.dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }
       
        void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (e.CellStyle.FormatProvider is ICustomFormatter)
            {
                e.Value = (e.CellStyle.FormatProvider.GetFormat(typeof(ICustomFormatter)) as ICustomFormatter).Format(e.CellStyle.Format, e.Value, e.CellStyle.FormatProvider);
                e.FormattingApplied = true;
            }
        }
        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            throw new NotImplementedException();
        }
        public class TimeSpanFormatter : IFormatProvider, ICustomFormatter
        {
            public object GetFormat(Type formatType)
            {
                if (formatType == typeof(ICustomFormatter))
                    return this;
                else
                    return null;
            }
            public string Format(string fmt, object arg, IFormatProvider formatProvider)
            {
                if (arg == null) return string.Empty;
                if (arg.GetType() != typeof(TimeSpan))
                    try
                    {
                        return HandleOtherFormats(fmt, arg);
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
                    }
                
                string tResult = string.Empty;
                try
                {
                    TimeSpan ts = (TimeSpan)arg;
                    tResult = string.Format("{0:N0}:{1}", ts.TotalHours,ts.Minutes);
                }catch (Exception ex)
                {
                    throw;
                }
                return tResult;
            }
            private string HandleOtherFormats(string format, object arg)
            {
                if (arg is IFormattable)
                    return ((IFormattable)arg).ToString(format, System.Globalization.CultureInfo.CurrentCulture);
                else if (arg != null)
                    return arg.ToString();
                else
                    return String.Empty;
            }
        }
    }
