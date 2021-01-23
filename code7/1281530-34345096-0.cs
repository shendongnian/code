    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyForm());
        }
        public class MyForm : Form
        {
            public MyForm()
            {
                this.InitializeComponents();
            }
            private void MyForm_Shown(object sender, EventArgs e)
            {
                this.SetDesktopLocation(Cursor.Position.X - 30, Cursor.Position.Y - 40);
            }
            private void InitializeComponents()
            {
                this.SuspendLayout();
                this.StartPosition = FormStartPosition.Manual ;
                
                var grid = new DataGridView { Dock = DockStyle.Fill };
                grid.Columns.Add("ColumnName", "HeaderText");
                // The form will load if I remove one of the two next lines:
                grid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                Controls.Add(grid);
                this.Shown += new System.EventHandler(this.MyForm_Shown);
                this.ResumeLayout(false);
            }
        }
    }
