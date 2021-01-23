    <ListView x:Name="listView">
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid VerticalAlignment="Center">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="50" />
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <TextBlock Grid.Column="0" Text="{Binding Quantity}" />
                    <TextBlock Grid.Column="1" Text="{Binding Name}" />
                </Grid>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
