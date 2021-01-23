    private void button1_MouseEnter(object sender, EventArgs e)
    {
        pictureBox1.Size = new Size(145, 145);            
        for (int i = 145; i < 290; i++)
        {
            pictureBox1.Size = new Size(i, i);
            pictureBox1.Update();
            System.Threading.Thread.Sleep(1);
        }
    }
