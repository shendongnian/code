    private void Move_Tick(object sender, EventArgs e)
    {
        int max = this.ClientSize.Width - Fantasma1.Width;
        int left = Fantasma.Left + 5;   // Tweak to adjust speed
        if (left >= max) {
            left = max;
            Move.Stop();
        }
        Fantasma.Left = left;
    }
