    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            // Force creation of window handle
            var dummy = txtHello.Handle;
            
            Task.Run(() =>
            {
                txtHello.Text = "Hello"; // kaboom
            });
        }
    }
