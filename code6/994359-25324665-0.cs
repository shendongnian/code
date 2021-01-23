    <Grid x:Name="my_grid" Loaded="my_grid_Loaded">
      <Grid.Background>
        <ImageBrush ImageSource="{Binding MainImage}"/>
      </Grid.Background>
    </Grid>
----------
    private void my_grid_Loaded(object sender, RoutedEventArgs e)
    {        
        Grid g = sender as Grid;
        System.Windows.Media.ImageBrush ib = g.Background as ImageBrush;                    
        if (ib.ImageSource == null)
        {
            g.Background = new SolidColorBrush(Colors.MYCOLOR);
        }
    }
