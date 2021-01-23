    <ItemsControl ItemsSource="{Binding MyCollection}">
        <!-- ItemsPanelTemplate -->
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
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
                </Grid>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
     
        <!-- ItemContainerStyle -->
        <ItemsControl.ItemContainerStyle>
            <Style>
                <Setter Property="Grid.Column"
                        Value="{Binding ColumnIndex}" />
                <Setter Property="Grid.Row"
                        Value="{Binding RowIndex}" />
            </Style>
        </ItemsControl.ItemContainerStyle>
     
        <!-- ItemTemplate -->
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Border Width="175" ...>
                    <TextBlock Text="{Binding Name}" />
                </Border>
        </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
