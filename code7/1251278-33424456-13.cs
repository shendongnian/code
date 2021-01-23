    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        points = getPolyList(colors.Take( (int) numericUpDown1.Value).ToList(),
                             pictureBox2.ClientSize);
        DrawPolyGradient(e.Graphics, points, pictureBox2.ClientRectangle);
    }
