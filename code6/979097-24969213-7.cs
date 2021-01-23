    public partial class PlotterDisplayEx : UserControl
    {         
        #region MEMBERS
        Control myTextCtl;
        public void RegisterCtl(Control ctl) { if (ctl != null) myTextCtl = ctl; }
        Component myTextComp;
        public void RegisterComp(Component comp) { if (comp != null) myTextComp = comp; } 
        //..
