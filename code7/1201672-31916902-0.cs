    <ItemsControl ItemsSource="{Binding ControlCollection}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid>
                    <Grid.RowDefinitions>
                        ...
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        ...
                    </Grid.ColumnDefinitions>
                </Grid>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        ...
    </ItemsControl>
