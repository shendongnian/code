    <ItemsControl ItemsSource="{Binding Sliders}">
        <ItemsControl.ItemTemplate>
            <DataTemplate DataType="{x:Type SliderData}">
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                    <TextBlock Text="{Binding Name}" />
                    <Slider Grid.Column="1" Value="{Binding Value}" />
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
