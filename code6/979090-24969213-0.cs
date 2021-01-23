    public partial class PlotterGraphSelectCurvesForm : Form
    {
        private int selectetGraphIndex = -1;
        private PlotterGraphPaneEx gpane = null;
        // block one: a Control reference (if you like!):
        public Control myTextCtl { get; set; }
        public void RegisterCtl(Control ctl) { if (ctl != null) myTextCtl = ctl; }
        // block one: a Component reference:
        public Component myTextComp { get; set; }
        public void RegisterComp(Component comp) { if (comp != null)  myTextComp = comp; }  
        //..
