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
            <!-- DataContext is MyCollection[0] -->
            <ContentPresenter Grid.Row="{Binding RowIndex}" Grid.Column="{Binding ColumnIndex}">
                <Border Width="175" ...> 
                    <TextBlock Text="{Binding Name}" />
                </Border>
            </ContentPresenter>
            <!-- DataContext is MyCollection[1] -->
            <ContentPresenter Grid.Row="{Binding RowIndex}" Grid.Column="{Binding ColumnIndex}">
                <Border Width="175" ...> 
                    <TextBlock Text="{Binding Name}" />
                </Border>
            </ContentPresenter>
            <!-- DataContext is MyCollection[2] -->
            <ContentPresenter Grid.Row="{Binding RowIndex}" Grid.Column="{Binding ColumnIndex}">
                <Border Width="175" ...> 
                    <TextBlock Text="{Binding Name}" />
                </Border>
            </ContentPresenter>
        </Grid>
    </ScrollViewer>
