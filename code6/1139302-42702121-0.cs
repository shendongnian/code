       public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[] que = new int[6];
            int x, y, z;
            Random ran = new Random();            
            for ( x = 0; x < 6; x++)
            {
                que[x] = ran.Next(1,49);
                for (y = x; y >= 0; y--)
                {
                    if (x == y)
                    {
                        continue;
                    }
                    if (que[x] == que[y])
                    {
                        que[x] = ran.Next(1,49);
                        y = x;
                    }
                }
            }
            listBox1.Items.Clear();
            for (z = 0; z < 6**strong text**; z++)
            {
                listBox1.Items.Add(que[z].ToString());
            }
        }
    }
