    <Grid>
        <ListView  HorizontalAlignment="Left" VerticalAlignment="Top" ItemsSource="{Binding ObjectCollection}" SelectedItem="{Binding SelectedItem}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition/>
                            <ColumnDefinition/>
                            <ColumnDefinition/>
                        </Grid.ColumnDefinitions>
                        <TextBox Width="100" Grid.Column="0" Text="{Binding Text}"/>
                        <Button Width="100" Content="Test" Grid.Column="1"/>
                        <Label Width="100" Grid.Column="2" Content="{Binding Label}"/>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
