    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            process p = new process();
            p.Progress += p_Progress;
            p.Foo();
        }
        void p_Progress(int value)
        {
            uiProgressBar.Value = value;
        }
    }
    public class process
    {
        public delegate void dlgProgress(int value);
        public event dlgProgress Progress;
        public void Foo()
        {
            // ... some code ...
            
            // calcuate the current progress position somehow:
            int i = (int)((double)3 / (double)10 * (double)100); // 30% complete
            // raise the event if there are subscribers:
            if (Progress != null)
            {
                Progress(i);
            }
        }
    }
