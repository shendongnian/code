        List<Control> controlsToBeRemoved = new List<Control>();
        foreach (Control item in this.Controls.OfType<PictureBox>())
        {
            controlsToBeRemoved.Add(item);
        }
        foreach (Control item in controlsToBeRemoved)
        {
            this.Controls.Remove(item);
        }
