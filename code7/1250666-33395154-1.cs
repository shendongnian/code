    public class DiagramNode : DiagramObject
    {
        private int xstep;
        public int XStep
        {
            get { return this.xstep; }
            set { this.xstep = value; }
        }
        ...
    }
    public class MainWindowViewModel : ViewModelBase
    {
        DiagramNode myDiagramNode = new DiagramNode();
        public MainWindowViewModel()
        {
            myDiagramNode.XStep = 3;
        }
    }
