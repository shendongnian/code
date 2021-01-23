    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True; //I'm assuming this is already set in your own source code as the cell is wrapping its text in your screenshot.
            panel1.AutoScroll = true;
            dataGridView1.AutoSize = true;
            FillGrid();
        }
        void FillGrid()
        {
            ...
        }
    }
