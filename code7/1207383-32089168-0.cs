       public partial class ProgressForm : Form
        {
            public ProgressForm()
            {
                InitializeComponent();
                this.TopMost = true;
            }
        
            public void SetProgress(int progress)
            {
                this.progressBar1.Value = progress;
                // Allow the form to be repainted
                Application.DoEvents();
            }
        } 
    
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            ProgressForm progressForm = new ProgressForm();
            void Task2()
            {
                ShowProgress(0);
                for (int i = 0; i < 10; i++ )
                {
                    System.Threading.Thread.Sleep(1000);
                    ShowProgress(i * 10);
                }
                HideProgress();
            }
    
    
            void ShowProgress(int progress)
            {
                if (!progressForm.Visible)
                    progressForm.Show();
                progressForm.SetProgress(progress);
            }
    
            void HideProgress()
            {
                progressForm.Hide();  // or Close, it depends from app logic
            }
    
    
            private void button1_Click(object sender, EventArgs e)
            {
                Task2();
            }
        }
