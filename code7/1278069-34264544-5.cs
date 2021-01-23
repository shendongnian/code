    public partial class UserControl1 : UserControl
    {
        TextBox textBox1;
        SelectablePanel selectablePanel;
        public UserControl1()
        {
            InitializeComponent();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox1.Location = new System.Drawing.Point(0, 0);
            this.Controls.Add(this.textBox1);
            selectablePanel = new SelectablePanel();
            selectablePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            selectablePanel.Location = new System.Drawing.Point(0, 25);
            selectablePanel.Size = new System.Drawing.Size(300, 150);
            selectablePanel.KeyDown += panel1_KeyDown;
            this.Controls.Add(this.selectablePanel);
            this.Size = new System.Drawing.Size(300, 200);
        }
        void panel1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Key down");
        }
    }
