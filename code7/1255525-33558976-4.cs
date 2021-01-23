    if(thisGenreComboBox.SelectedIndex>-1)
    {
        var imageName = ((Book)thisGenreComboBox.SelectedItem).Image;
        var file = System.IO.Path.Combine(Application.StartupPath, "Images" , imageName);
        thisGenrePictureBox.Image = Image.FromFile(file);
    }
