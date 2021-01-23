    public partial class MainWindow : Window
    {
        public List<Schedule> _schedules { get; set; }
        List<MyTask> _dbContext = new List<MyTask>();
        public MainWindow()
        {
            InitializeComponent();
            _schedules = new List<Schedule>();
            LoadTimeIntervals(DateTime.Now);
            LoadDbContext();
            LoadTasks();
            DataContext = this;
        }
        private void LoadTimeIntervals(DateTime selectedDate)
        {
            var starting = DateTime.Parse(selectedDate.Date.ToShortDateString() + " 00:00:00");
            for (var i = starting; i < DateTime.Parse(selectedDate.Date.ToShortDateString() + " 23:59:00"); i += new TimeSpan(0, 30, 0))
            {
                _schedules.Add(new Schedule() { TaskDT = i, Tasks = new List<MyTask>() });
            }
        }
        private void LoadTasks()
        {
            foreach (var interval in _schedules)
            {
                interval.Tasks = _dbContext.Where(x => x.DueDt == interval.TaskDT).ToList();
            }
        }
        private void LoadDbContext()
        {
            for (int i = 1; i < 24; i++)
            {
                if ((i & 1) == 0)
                    _dbContext.Add(new MyTask() { DueDt = DateTime.Parse(DateTime.Now.Date.ToShortDateString() + " " + i.ToString().PadLeft(2, '0') + ":00:00"), Name = "Task #" + i.ToString(), Completed = false });
            }
            for (int i = 1; i < 24; i++)
            {
                if ((i & 1) == 0)
                    _dbContext.Add(new MyTask() { DueDt = DateTime.Parse(DateTime.Now.Date.ToShortDateString() + " " + i.ToString().PadLeft(2, '0') + ":00:00"), Name = "Task #" + i + 24, Completed = false });
            }
        }
    }
    public class Schedule
    {
        public DateTime TaskDT { get; set; }
        public List<MyTask> Tasks { get; set; }
    }
    public class MyTask
    {
        public DateTime DueDt { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
    }
