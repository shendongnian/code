    public partial class Form1 : Form
    {
        CancellationTokenSource src;
        CancellationToken t;
        
        public Form1()
        {
            InitializeComponent();
        }
        //start incrementing
        private async void button1_Click(object sender, EventArgs e)
        {
            this.Start.Enabled = false;
            this.Cancel.Enabled = true;
            this.src = new CancellationTokenSource();
            this.t = this.src.Token;
            try
            {
                while (true)
                {
                    var tsk = Task.Factory.StartNew<int>(() =>
                    {
                        Task.Delay(500);
                        var txt = int.Parse(this.Display.Text) + 1;
                        return (txt);
                    }, this.t);
                    var result = await tsk;
                    this.Display.Text = result.ToString();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        // Stop incrementing
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.src.Cancel();
            this.Cancel.Enabled = true;
            this.Start.Enabled = true;
        }
    }
