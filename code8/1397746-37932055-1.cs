    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            this.DataContext = new TaskViewModel();
        }
    }
 
    class TaskViewModel
    {
        public ObservableCollection<Task> TaskList { get; set; }
        public TaskViewModel()
        {
            TaskList = new ObservableCollection<Task>();
            for (int i = 0; i < 10; i++)
            {
                Task task = new Task();
                task.TaskId = (i + 1).ToString();
                task.TaskName = "Task Name" + (i + 1).ToString();
                TaskList.Add(task);
            }
        }
    }
    class Task
    {
        public string TaskId { get; set; }
        public string TaskName { get; set; }
        
    }
