    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <ListView ItemsSource="{Binding PassedData}" HorizontalAlignment="Center" VerticalAlignment="Center">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="auto"/>
                            <ColumnDefinition Width="auto"/>
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="auto"/>
                        </Grid.RowDefinitions>
                        <TextBox Grid.Column="0" Text="{Binding Name}" />
                        <TextBox Grid.Column="1" Text="{Binding Value}" />
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
