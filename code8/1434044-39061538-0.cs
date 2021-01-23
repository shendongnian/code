    public partial class Form1 : Form
    {
            System.Timers.Timer t = new System.Timers.Timer(TimeSpan.FromMinutes(5).TotalMilliseconds);
            bool start == false;
          
            public Form1()
            {
                InitializeComponent();
                t.AutoReset = true;
                t.Elapsed += new System.Timers.ElapsedEventHandler(my_method);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (start == false)
                {
                    t.Start();
                    start = true;
                    Checkbutton.Text = "End";
                }
                else
                {
                    t.Stop();
                    t.AutoReset = false;
                    Checkbutton.Text = "Begin";
                    MessageBox.Show("Auto Check Stop!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
    }
