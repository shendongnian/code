    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        static extern bool SetSystemTime([In] ref SYSTEMTIME st);
        public Form1()
        {
            InitializeComponent();
        }
        public struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
            public void FromDateTime(DateTime time)
            {
                wYear = (ushort)time.Year;
                wMonth = (ushort)time.Month;
                wDayOfWeek = (ushort)time.DayOfWeek;
                wDay = (ushort)time.Day;
                wHour = (ushort)time.Hour;
                wMinute = (ushort)time.Minute;
                wSecond = (ushort)time.Second;
                wMilliseconds = (ushort)time.Millisecond;
            }
            public DateTime ToDateTime()
            {
                return new DateTime(wYear, wMonth, wDay, wHour, wMinute, wSecond, wMilliseconds);
            }
            public static DateTime ToDateTime(SYSTEMTIME time)
            {
                return time.ToDateTime();
            }
        }
        private void BtnChangeDate_Click(object sender, EventArgs e)
        {
            ChangeDateUp(0);
        }
        private void BtnPreviousDay_Click(object sender, EventArgs e)
        {
            ChangeDateDown(0);
        }
        private void ChangeDateUp(int numDays)
        {            
            DateTime t = DateTime.Now.AddDays(1);
            SYSTEMTIME st = new SYSTEMTIME();
            st.FromDateTime(t);
            SetSystemTime(ref st);
        }
        private void ChangeDateDown(int numDays)
        {
            DateTime t = DateTime.Now.AddDays(-1);
            SYSTEMTIME st = new SYSTEMTIME();
            st.FromDateTime(t);
            SetSystemTime(ref st);
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
