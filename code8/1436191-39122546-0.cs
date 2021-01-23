     <Grid x:Name="SourceGrid">
            <Grid.ColumnDefinitions>
                <ColumnDefinition />
                <ColumnDefinition />
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition />
                <RowDefinition />
            </Grid.RowDefinitions>
            <TextBlock Grid.Row="0"
                       Grid.Column="0"
                       Text="Headers" />
            <TextBlock Grid.Row="0"
                       Grid.Column="1"
                       Text="Tags" />
            <ItemsControl Grid.Row="1"
                          Grid.ColumnSpan="2"
                          ItemsSource="{Binding Path=AllHeaders.Fields}">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <Grid x:Name="SourceGrid">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition />
                                <ColumnDefinition />
                            </Grid.ColumnDefinitions>
                            <TextBlock Text="{Binding}"
                                       Grid.Column="0" />
                            <ComboBox ItemsSource="{Binding ElementName=SourceGrid, Path=DataContext.Tags}"
                                      Grid.Column="1"/>
                        </Grid>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
        </Grid>
