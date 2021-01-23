    public partial class Form1 : Form
    {
        private SoundPlayer simpleSound; 
        private bool SoundPlaying = false;
        
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        void Form1_Load(object sender, EventArgs e)
        {
            simpleSound = new SoundPlayer(@"c:\Windows\Media\shortwav.wav");
            simpleSound.LoadAsync();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Tick");
            if (true) // check your condition
            {
                this.PlaySound();
            }
        }
        private void PlaySound()
        {
            if (!this.SoundPlaying)
            {
                Console.WriteLine("Starting Sound");
                this.SoundPlaying = true;
                Task.Factory.StartNew(() => {
                    simpleSound.PlaySync();
                    this.SoundPlaying = false;
                });
            }
        }
    }
