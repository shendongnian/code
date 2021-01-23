    public partial class PlotterDisplayEx : UserControl
    {         
        #region MEMBERS
        public Control myTextCtl { get; set; }
        public void RegisterCtl(Control ctl) { if (ctl != null) myTextCtl = ctl; }
        public Component myTextComp { get; set; }
        public void RegisterComp(Component comp) { if (comp != null) myTextComp = comp; } 
        //..
