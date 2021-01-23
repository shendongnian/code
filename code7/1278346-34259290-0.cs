    int length;
    if (int.TryParse(txtBox_Length.Text, out length))
    {
        newMovie.movieLength = length;
        txtBox_Length.Background = new SolidColorBrush(Colors.LightGray);
    }
    else
    {
        txtBox_Length.Background = new SolidColorBrush(Colors.Red);
        MessageBox.Show("Please enter movie length in minutes.");
        isGoodToAddNewMovie = false;
    }
