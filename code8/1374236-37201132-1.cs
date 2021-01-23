        <ListBox ItemsSource="{Binding Scores}" Grid.IsSharedSizeScope="True">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto" SharedSizeGroup="JmenoColumn"/>
                            <ColumnDefinition Width="Auto" SharedSizeGroup="PenizeColumn"/>
                        </Grid.ColumnDefinitions>
                        <TextBlock Grid.Column="0" Margin="0,0,10,0" Text="{Binding Jmeno}"/>
                        <TextBlock Grid.Column="1" Text="{Binding Penize}"/>
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
