    public class MainWindowViewModel : ViewModelBase
    {
        DiagramNode myDiagramNode = new DiagramNode();
        public MainWindowViewModel()
        {
            // Initialization
            Step = 3;
            myDiagramNode.xstep = 3;
        }
    }
