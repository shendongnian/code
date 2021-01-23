    <ListBox.ItemTemplate>
        <DataTemplate>
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*"/>
                    <ColumnDefinition Width="Auto"/>
                </Grid.ColumnDefinitions>
                <TextBlock Grid.Column="0" Text="{Binding Data}"></TextBlock>
                <TextBlock Grid.Column="1" Text="x"></TextBlock >
            </Grid>
        </DataTemplate>
    </ListBox.ItemTemplate>
