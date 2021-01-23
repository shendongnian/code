    <Window>
        <ListBox  ItemsSource="{Binding Items}" >
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="100"/>
                            <ColumnDefinition Width="100"/>
                            <ColumnDefinition Width="100"/>
                        </Grid.ColumnDefinitions>
                        <TextBlock Grid.Column="0" Text="{Binding Item1}" />
                        <TextBlock Grid.Column="1" Text="{Binding Item2}" />
                        <TextBlock Grid.Column="2" Text="{Binding Item3}" />
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Window>
