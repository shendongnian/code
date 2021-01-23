    private void ImageHeight200_Click(object sender, System.Windows.RoutedEventArgs e){
    MenuItem mnu = sender as MenuItem;
    Image sp = null;
    if(mnu!=null)
    {
        sp = ((ContextMenu)mnu.Parent).PlacementTarget as Image;
    }}
