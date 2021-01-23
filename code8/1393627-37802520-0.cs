    <Grid VerticalAlignment="Top">
        <ListView x:Name="lv" ItemsSource="{Binding}" >
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid Background="Salmon" VerticalAlignment="Top">
                        <ListView ItemsSource="{Binding Items}" Height="Auto">
                            <ListView.ItemTemplate>
                                <DataTemplate>
                                    <TextBlock Text="{Binding StudentName}"/>
                                </DataTemplate>
                            </ListView.ItemTemplate>
                        </ListView>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
            <ListView.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel Orientation="Horizontal" />
                </ItemsPanelTemplate>
            </ListView.ItemsPanel>
        </ListView>
    </Grid>
