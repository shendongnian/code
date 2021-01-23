     <Grid>
          <Button Name="button1" Click="button1_Click">
          </Button>
      </Grid>
     private void button1_Click(object sender, RoutedEventArgs e)
            {
                Uri uri = new Uri("image path", UriKind.Relative);
                BitmapImage img = new BitmapImage(uri);
                button2.Background = new ImageBrush(img );
            }
