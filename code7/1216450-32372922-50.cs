    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
       if (rb_pen.Checked) currentLine.Add(e.Location);
       else if (rb_stamp.Checked)
       {
           { stampIntoImage(e.Location); };
       }
    }
