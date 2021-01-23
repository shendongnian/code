    [ComVisible(true)]
    public partial class Form1 : Form, Visio.IVisEventProc
    {
        public Form1()
        {
            InitializeComponent();
        }
        Visio.Application app;
        bool initialised = false;
        private void button1_Click(object sender, EventArgs e)
        {
            init();
            app.Documents.Add("C:\\test.vst"); // creates new document from template
        }
        void init()
        {
            if (!initialised)
            {
                // only initialise once
                app = new Visio.Application();
                // app.BeforeDocumentClose += app_BeforeDocumentClose;
                app.EventList.AddAdvise(DocCloseEventCode, this, null, null);
                initialised = true;
                Application.DoEvents();
            }
        }
        const short DocCloseEventCode = unchecked((short)Visio.VisEventCodes.visEvtDoc + (short)Visio.VisEventCodes.visEvtDel);
        object Visio.IVisEventProc.VisEventProc(short eventCode, object source, int eventID, int eventSeqNum, object subject,object moreInfo)
        {
            if (eventCode == DocCloseEventCode)
                app_BeforeDocumentClose(subject as Visio.Document);
            return null;
        }
        void app_BeforeDocumentClose(Visio.Document doc)
        {
        }
    }
