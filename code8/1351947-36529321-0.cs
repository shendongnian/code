    private void cb_ApplyText_Click(object sender, EventArgs e)
    {
        Graphics g = Graphics.FromImage(pictureBox1.Image);
        g.DrawString(textBox1.Text,
            new Font("Tahoma", Convert.ToInt32(numericUpDown1.Value)),
            new SolidBrush(foreColor), textLocation);
        textLocation = Invalid;
        pictureBox1.Refresh();
    }
