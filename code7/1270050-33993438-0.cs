     // (5 of these) x (60 pictureboxes in each) = 300 images in all:
     for (int panelNumber = 0; panelNumber < 5; i++) {
        Panel panel = new Panel();
        panel.Height = 30000; 
        panel.Top = panelNumber * 30000;
        // ...anything else needed to set up the panel...      
        for (int PictureBoxNr = 0; PictureBoxNr< 60; i++) {
            PictureBox picbox = new PictureBox();
            picbox.BackColor = Color.Red;
            picbox.Width = 500;
            picbox.Height = 250;
            picbox.Top = PictureBoxNr * 500;
            panel.Controls.Add(picbox);
        }
        outerPanel.Controls.Add(panel);
    }
