    for (int i = 0; i <= 19; i++)
    {
        var pictureBox = (PictureBox) Form2.ActiveForm.Controls.Find("PB" + i, true)[0];
        pictureBox.Tag = i;
        pictureBox.Click += (sender, args) =>
        {            
            msgShow((int)((sender as PictureBox).Tag)));
        };
    }
