    <Image Grid.Row="0" Grid.Column="0" Source="Assets/img.png"  Tapped="image_Tapped" />
    private void image_Tapped(object sender, TappedRoutedEventArgs e)
    {
        Image img = sender as Image;
        int row = Grid.GetRow(img);
        int col = Grid.GetColumn(img);
    }
