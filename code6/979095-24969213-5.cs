    public partial class PlotterGraphSelectCurvesForm : Form
    {
        private int selectetGraphIndex = -1;
        private PlotterGraphPaneEx gpane = null;
        // block one: a Control reference (if you like!):
        Control myTextCtl;
        public void RegisterCtl(Control ctl) { if (ctl != null) myTextCtl = ctl; }
        // block one: a Component reference:
        Component myTextComp;
        public void RegisterComp(Component comp) { if (comp != null)  myTextComp = comp; }  
        //..
