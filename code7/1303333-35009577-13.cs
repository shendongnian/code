    <ItemsControl ItemsSource="{Binding Names}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid x:Name="innerGrid" Loaded="OnGridLoaded" DataContext="{Binding Name, Mode=OneWay}">
                        <TextBox Text="{Binding Path=., Mode=OneWay}" />
                    </Grid>
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
