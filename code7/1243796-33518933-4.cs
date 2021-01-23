    foreach (Control but in tabPage2.Controls)
    {
      but.Parent = pictureBox1;
      but.BackColor = Color.Transparent;
    }
      
    Application.DoEvents();
