    xaml
    
    <ListView Name="listView1">
         <ListView.ItemTemplate>
              <DataTemplate>
                   <Grid>
                        <Image Source="{Binding}" Height="50" Width="50" Stretch="UniformToFill" />
                   </Grid>
               </DataTemplate>
          </ListView.ItemTemplate>
    </ListView>
    
    и в коде добавляем List<BitmapImage>
    
    List<BitmapImage> data_list = new List<BitmapImage>();
    
    foreach (var stuff in query)
            {
                string FileName;
                FileName = stuff.RecipeImage;
                var file = await
                Windows.Storage.KnownFolders.PicturesLibrary.GetFileAsync(FileName);
                BitmapImage bitmapImage;
                using (var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    bitmapImage = new BitmapImage();
                    bitmapImage.SetSource(stream);
                }
    
              data_list.Add(bitmapImage);
            }
    
     listView1.ItemsSource = data_list; 
