    namespace GanttC
    {
       public partial class Example : Form
       {
            ProjectManager _mProject;
            public Example()
            {
               InitializeComponent();
               _mProject = new ProjectManager();
               _mProject.Add(new Task() { Name = "New Task" });
               _mChart.Init(_mProject);
            }
    
            public int Test()
            {
                return 2 + 2;
            }
        }
    }
