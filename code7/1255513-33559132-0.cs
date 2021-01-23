        public int x = 0;
        public int y = 0;
        private Label[] moku =  new Label[361];
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 361; i++)
                {
                    moku[i] = new Label();
                    moku[i].Parent = pictureBox1;//make the picturebox parent
                    moku[i].Location = new Point(x, y);
                    moku[i].Text = "O";
                    moku[i].Name = "moku" + i;
                    moku[i].BackColor = Color.Transparent;
                    pictureBox1.Controls.Add(moku[i]);
                    y += 55;
                    if (y >= 361) { x += 55; y = 0; x+=55; }
                }
            }catch(Exception er)
            {
                MessageBox.Show(er.ToString());
            }
            
        }
