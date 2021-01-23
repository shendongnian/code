    public partial class Form1 : Form
    {
        CvsInSight insight = new CvsInSight();
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            insight.Connect("127.0.0.1", "admin", "", false, false);
            insight.ResultsChanged += insight_ResultsChanged;
        }
    
        void insight_ResultsChanged(object sender, EventArgs e)
        {
            // Here: Consider inserting code to check that this event
            // has been triggered by an image acquisition
    
            CvsResultSet results = insight.Results;
            // Note the reference below to row 10, column 3 (cell D10)
            CvsCell cell = results.Cells.GetCell(10, 3);
            if (cell == null)
            {
                MessageBox.Show("Error: Cell D10 is null");
                return;
            }
            if (cell.DataType != CvsCellDataType.FloatingPoint) {
                MessageBox.Show("Error: Unexpected data type at cell D10");
                return;
            }
            CvsCellFloat floatCell = (CvsCellFloat)cell;
            MessageBox.Show("Floating point value at cell D10 is: " + floatCell.Value.ToString());
        }
    
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            insight.Disconnect();
        }
