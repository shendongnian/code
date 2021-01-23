    <ScrollViewer>
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition />
                <RowDefinition />
                <RowDefinition />
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition />
                <ColumnDefinition />
                <ColumnDefinition />
            </Grid.ColumnDefinitions>
            <Border Width="175" ...> <!-- DataContext is MyCollection[0] -->
                <TextBlock Text="{Binding Name}" />
            </Border>
            <Border Width="175" ...> <!-- DataContext is MyCollection[1] -->
                <TextBlock Text="{Binding Name}" />
            </Border>
            <Border Width="175" ...> <!-- DataContext is MyCollection[2] -->
                <TextBlock Text="{Binding Name}" />
            </Border>
        </Grid>
    </ScrollViewer>
