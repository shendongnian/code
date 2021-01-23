    foreach (Control c in this.Controls)
    {
         if (c is PictureBox)
         {
              c.BackColor = Color.Red;
         }
    }
