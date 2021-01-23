    public partial class CheckSeriesBox : ComboBox
    {
        private static List<string> CheckSeries;
    
        public CheckSeriesBox()
        {
            InitializeComponent();
    
            CheckSeries = new List<string>();
            SetCheckSeries();
    
            if (DesignMode)
            {
                 this.Items.AddRange(CheckSeries.ToArray());
            }
        }
    
        public static List<string> SetCheckSeries()
        {
            CheckSeries.Add("A");
            CheckSeries.Add("B");
        }
    
        protected new bool DesignMode
        {
            get
            {
                if (base.DesignMode)
                {
                    return true;
                }
                else
                {
                    Control parent = this.Parent;
                    while ((parent != null))
                    {
                        System.ComponentModel.ISite site = parent.Site;
                        if ((site != null) && site.DesignMode)
                        {
                            return true;
                        }
                        parent = parent.Parent;
                    }
                    return false;
                }
            }
        }
    
    }
