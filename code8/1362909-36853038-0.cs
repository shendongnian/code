    public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
            }
            SpeechRecognizer sRecognize = new SpeechRecognizer();
            private void Form1_Load(object sender, EventArgs e)
            {
                sRecognize.SpeechRecognized += sRecognize_SpeechRecognized;
    
            }
            void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            {
             
            }
