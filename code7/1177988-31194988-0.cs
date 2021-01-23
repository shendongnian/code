    public partial class MainWindow : Window
    {      
        public MainWindow ()
        {
            InitializeComponent();
            OpenProjectsView();
        }
        private void OpenProjectsView()
        {
            ProjectsView projectWindow= new ProjectsView();
            projectWindow.Owner = this;
            projectWindow.TopMost = true;
            projectWindow.Show();
        }
    }
