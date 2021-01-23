        private void button1_MouseHover(object sender, EventArgs e)
        {
            AnimateButton.Animate((Button)sender, AnimateButton.Direction.Grow);
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            AnimateButton.Animate((Button)sender, AnimateButton.Direction.Shrink);
        }
