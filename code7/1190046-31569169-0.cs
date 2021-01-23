    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void textBoxEx1_StableTextChanged(object sender, EventArgs e)
        {
            label1.Text = ((TextBoxEx)sender).Text;
        }
    }
    public class TextBoxEx : TextBox
    {
        public event dlgStableTextChanged StableTextChanged;
        public delegate void dlgStableTextChanged(object sender, EventArgs e);
        private System.Windows.Forms.Timer tmr;
        public TextBoxEx()
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 1000;
            tmr.Tick += Tmr_Tick;
            this.TextChanged += TextBoxEx_TextChanged;
        }
        private void Tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            if (this.StableTextChanged != null)
            {
                this.StableTextChanged(this, new EventArgs());
            }
        }
        private void TextBoxEx_TextChanged(object sender, EventArgs e)
        {
            tmr.Stop();
            tmr.Start();
        }
    }
