    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.monthCalendar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.monthCalendar1_MouseDown);
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime d = monthCalendar1.SelectionRange.Start;
            Console.WriteLine(d.Month.ToString()); //Get the month selected. 
        }
        private void monthCalendar1_MouseDown(object sender, MouseEventArgs e)
        {
            int i = (int)monthCalendar1.SelectionStart.DayOfWeek;
            DateTime d = monthCalendar1.SelectionStart;
            monthCalendar1.SelectionStart = d.AddDays(1 - i);
            monthCalendar1.SelectionEnd = d.AddDays(7 - i);
        }
    }
