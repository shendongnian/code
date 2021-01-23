    public partial class MainWindow : Window
    {
        List<Schedule> _schedules = new List<Schedule>(); // << Bind to datacontext and wire up UI elements.
        public MainWindow()
        {
            InitializeComponent();
            LoadTimeIntervals(DateTime.Now);
            LoadTasks();
            DataContext = _schedules;
        }
        private void LoadTimeIntervals(DateTime selectedDate)
        {
            var starting = DateTime.Parse(selectedDate.Date.ToShortDateString() + " 00:00:00");
            for (var i = starting; i < DateTime.Parse(selectedDate.Date.ToShortDateString() + " 23:59:00"); i += new TimeSpan(0,30,0))
            {
                _schedules.Add(new Schedule() { TaskDT = i,  Tasks = new List<MyTaskModel>() });
            }
        }
        private void LoadTasks()
        {
            foreach (var interval in _schedules)
            {
                using (var db = new DbDataContext())
                {
                    .... \\Load db entries for this interval and add tasks to the tasks list in the model.
                }
            }
        }
    }
    public class Schedule
    {
        public DateTime TaskDT { get; set; }
        public List<MyTaskModel> Tasks { get; set; }
       
    }
