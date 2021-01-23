    private void textBox1_DragEnter(object sender, DragEventArgs e)
    {
        if ((e.AllowedEffect & DragDropEffects.Link) != 0
          && e.Data.GetDataPresent(typeof(Button)))
            e.Effect = DragDropEffects.Link;
    }
    private void textBox1_DragDrop(object sender, DragEventArgs e)
    {
        Button btn = e.Data.GetData(typeof(Button)) as Button;
        btn.Parent = textBox1;
        btn.Location = new Point(textBox2.Width - btn.Width - 2, -2);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        textBox1.Text = "The Button is still working!";
    }
    // we use the MouseMove with a check for the left button
    private void button1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
           DoDragDrop((sender as Button), DragDropEffects.Link); 
    }
