    if(thisGenreComboBox.SelectedIndex>-1)
    {
        var imageName = string.Format("{0}Cover.jpg", thisGenreComboBox.SelectedItem);
        var file = System.IO.Path.Combine(Application.StartupPath, "Images" , imageName);
        thisGenrePictureBox.Image = Image.FromFile(file);
    }
