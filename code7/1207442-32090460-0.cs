        Form2 f2 = new Form2();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            f2.Show();
            while (i < listBox1.Items.Count)
            {
                string strpath = listBox1.Items[i].ToString();
                string[] str1 = strpath.Split(',');
                f2.updateimage(str1[0]);
                f2.Update();// Add This Line to make the second form update it self
                System.Threading.Thread.Sleep(5000);
                String Blankimage = @"C://Blankimage.bmp";     
                f2.updateimage(Blankimage);
                f2.Update(); // Add This Line to make the second form update it self
                System.Threading.Thread.Sleep(1000);
                i++;
            }
        }
    }
