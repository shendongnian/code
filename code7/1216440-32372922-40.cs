    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            if (rb_pen.Checked)
            {
                currentLine.Add(e.Location);
                drawIntoImage();
            }
            else if (rb_stamp.Checked) { stampIntoImage(e.Location); };
        }
        else if (rb_test.Checked) drawTest(e.Location);
    }
