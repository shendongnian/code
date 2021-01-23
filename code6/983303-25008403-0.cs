    public class XtraReport1 : XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
        }
        public ReportParameters ParaObjectSource {get; set;}
        protected override void OnBeforePrint(PrintEventArgs e)
        {
            base.OnBeforePrint(e);
            //Create parameters for report from your ParaObjectSource 
        }
    }
