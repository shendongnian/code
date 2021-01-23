    <FlipView x:Name="flipView" ItemsSource="{Binding ListTest}" HorizontalContentAlignment="Center" VerticalContentAlignment="Center" >
                <FlipView.ItemTemplate>
                    <DataTemplate>
                        <Grid x:Name="grid" Background="Blue" >
                            <Grid.RowDefinitions>
                                <RowDefinition Height="3*"/>
                                <RowDefinition />
                            </Grid.RowDefinitions>
                            <Grid Grid.RowSpan="2" x:Name="image">
                                <Image  Stretch="Uniform" SizeChanged="Image_SizeChanged"  Source="{Binding Url}" ></Image>
                            </Grid>
                            <Grid   x:Name="textblockgrid" Grid.Row="1" Background="Gray">
                                <TextBlock Foreground="White" TextWrapping="Wrap"  HorizontalAlignment="Left" FontSize="20" Text="TEXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX trysffffffffffffff sdfffffffffffff dfhdffffffffffffff dfhhhhhhhhX"/>
                            </Grid>
                        </Grid>
                    </DataTemplate>
                   
    
                    </FlipView.ItemTemplate>
    
            </FlipView>
    
    
        private void Image_SizeChanged(object sender, SizeChangedEventArgs e)
        {
          FlipViewItem item = (FlipViewItem) flipView.ContainerFromItem((sender as Image).DataContext);
          var text =  FindElementInVisualTree<TextBlock>(item);
            (text.Parent as Grid).Width = (sender as Image).ActualWidth;
        }
        private T FindElementInVisualTree<T>(DependencyObject parentElement) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(parentElement);
            if (count == 0) return null;
    
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parentElement, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    var result = FindElementInVisualTree<T>(child);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
