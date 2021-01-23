    <Grid>
        <Grid.Resources>
            <Style TargetType="{x:Type ListViewItem}">
                <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=OneWayToSource}"/>
            </Style>
        </Grid.Resources>
        <ListView ItemsSource="{Binding ViewModelList}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding IsSelected}"/>
                </DataTemplate>
            </ListView.ItemTemplate>
            <ListView.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel Orientation="Horizontal">
                    </StackPanel>
                </ItemsPanelTemplate>
            </ListView.ItemsPanel>
        </ListView>
    </Grid>
