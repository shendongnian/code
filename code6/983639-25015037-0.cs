    foreach (var pBox in new lstBox.Items.Cast<PictureBox>())
    {
        if (pBox.BackColor == Color.White)
        {
            counterWhite += 1;
        }
        ...
    }
