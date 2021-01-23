    public partial class Form1 : Form
    {
        Microsoft.Office.Interop.Excel.Worksheet ws;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ws = Globals.ThisAddIn.Application.ActiveSheet;
            ws.SelectionChange += ws_SelectionChange;            
            
        }
        void ws_SelectionChange(Microsoft.Office.Interop.Excel.Range Target)
        {
            this.textBox1.Text = Target.Address; 
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ws.SelectionChange -= ws_SelectionChange;
        }
    }
