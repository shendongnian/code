    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Random R = new Random();
        private List<Button> Buttons = new List<Button>();
        private void button1_Click(object sender, EventArgs e)
        {
            while (Buttons.Count > 0)
            {
                Buttons[0].Dispose();
                Buttons.RemoveAt(0);
            }
            
            bool overlapping;
            for(int i = 1; i <= 10; i++)
            {
                Button btn = new Button();
                btn.Text = i.ToString();
                this.Controls.Add(btn);
                do
                {
                    overlapping = false;
                    btn.Location = new Point(R.Next(this.ClientSize.Width - btn.Width), R.Next(this.ClientSize.Height - btn.Height));
                    foreach(Button otherBtn in Buttons)
                    {
                        if (btn.Bounds.IntersectsWith(otherBtn.Bounds))
                        {
                            overlapping = true;
                            break;
                        }
                    }
                } while (overlapping);
                Buttons.Add(btn);
            }
        }
    }
