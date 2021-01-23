    <ItemsControl ItemsSource="{Binding FileSelections}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition/>
                        <ColumnDefinition Width="Auto"/>
                    </Grid.ColumnDefinitions>
                </Grid>
                <TextBox Text="{Binding FilePath}" Margin="2"/>
                <Button Command="{Binding BrowseFileCommand}" Margin="2"/>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
