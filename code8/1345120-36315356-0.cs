    private void Win()
    {
        if (cardsHolder.Controls.OfType<PictureBox>().Any(pb => pb.Image == null))
            return;
        MessageBox.Show("You matched all the icons!", "Congratulations");
        Close(); 
    }
