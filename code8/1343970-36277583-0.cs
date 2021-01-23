     private void gridGameBoard_Tapped(object sender, TappedRoutedEventArgs e)
                {
                    Grid grd = sender as Grid;
                 int i =    Grid.GetColumn(grd);//To get column no
                 Grid.GetRow(grd);//To get row no
                }
