    public partial class Form1 : Form
    {
        List<int> rids = null;
        Random rand = new Random();
    
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(new Control());
        }
        
    
        private void DisplayValues()
        {            
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is TextBox) if(Controls[i].Name.Contains("txt"))
                    Controls[i].Text = rids[Int32.Parse(Controls[i].Name.Replace("txt", "")) - 1].ToString();
            }
        }
    
        private void button1_Click_1(object sender, EventArgs e)
        {
            rids = new List<int>()
            { 
               RandomNumber(-111, 999),
               RandomNumber(-111, 999),
               RandomNumber(-222, 888),
               RandomNumber(-333, 777),
               RandomNumber(-222, 777),
               RandomNumber(-333, 444),
               RandomNumber(-555, 888),
               RandomNumber(444, 999),
               RandomNumber(111, 222),
               RandomNumber(222, 333)
            };
    
            DisplayValues();  // use it if you want to show your values in UI
        }
    
        private int RandomNumber(int p1, int p2)
        {
            return rand.Next(p1, p2);
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            rids.Sort();
    
            DisplayValues();
        }
    }
