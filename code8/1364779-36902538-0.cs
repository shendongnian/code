    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var mTab = new MyTab();
            mTab.Location = new System.Drawing.Point(100, 100);
            // The OnClick will only work on the 
            // Tabs themselves so Pages must be added to display the Tabs.
            var mtabPage1 = new System.Windows.Forms.TabPage();
            mTab.Controls.Add(mtabPage1);
            this.Controls.Add(mTab);
        }
        class MyTab : TabControl
        {
            protected override void OnClick(EventArgs e)
            {
                MessageBox.Show("I was clicked.");
                base.OnClick(e);
            }
        }
    }
