        public partial class MainForm : Form
        {
            /// <summary>
            /// Some progress form
            /// </summary>
            WaitForm waitForm = new WaitForm();
    
            /// <summary>
            /// https://msdn.microsoft.com/library/cc221403(v=vs.95).aspx
            /// </summary>
            BackgroundWorker worker = new BackgroundWorker();
    
            public MainForm()
            {
                InitializeComponent();
    
                worker.DoWork += (sender, args) => PerformReading();
                worker.RunWorkerCompleted += (sender, args) => ReadingCompleted();
            }
    
            /// <summary>
            /// This method will be executed in an additional thread
            /// </summary>
            void PerformReading()
            {
                //some long operation here
                Thread.Sleep(5000);
            }
    
            /// <summary>
            /// This method will be executed in a main thread after BackgroundWorker has finished
            /// </summary>
            void ReadingCompleted()
            {                        
               waitForm.Close();
            }
            
            private void button1_Click(object sender, EventArgs e)
            {
                //Run reading in an additional thread
                worker.RunWorkerAsync();
                //Show progress form in a main thread
                waitForm.ShowDialog();
            }
        }
