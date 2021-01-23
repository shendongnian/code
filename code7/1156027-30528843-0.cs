        //Sample object representing one of your pictures
        PictureBox pb1 = new PictureBox();
        List<PictureBox> images = new List<PictureBox>();
        images.Add(pb1);
        int frameSize = 5;
        PictureBox popup = new PictureBox();
        popup.Visible = false;
        popup.MouseLeave += (s, a) =>
        {
            popup.Visible = false;
        };
        foreach (var pb in images)
        {
            pb.MouseEnter += (s, a) =>
            {
                var sender = (PictureBox)s;
                popup.Image = sender.Image;
                popup.Left = sender.Left - frameSize;
                popup.Top = sender.Top - frameSize;
                popup.Width = sender.Width + (2 * frameSize);
                popup.Height = sender.Height + (2 * frameSize);
                popup.Visible = true;
                popup.BringToFront();
            };
        }
