    public class Projects
    {
        public string Tasks { get; set; }
        public bool IsCompleted { get; set; }
    }
    public sealed partial class MainPage : Page
    {
        public LinkedList<Projects> NewProject { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            NewProject = new LinkedList<Projects>();
            NewProject.AddLast(new Projects() {Tasks="Task1",IsCompleted=true});
            NewProject.AddLast(new Projects() { Tasks = "Task2", IsCompleted = false });
            NewProject.AddLast(new Projects() { Tasks = "Task3", IsCompleted = true });
            this.DataContext = this;
        }
