    <ListBox ItemsSource="{Binding Path=MyInfoCollection}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Grid.Column="0" Text="{Binding Path=EntryDate}" />
                    <TextBlock Grid.Column="1" Text="{Binding Path=NoteText}" />
                    <Image Grid.Column="2" Source="{Binding Path=ImagePath}" />
                </Grid>
            </DataTemplate>
        </ListBox .ItemTemplate>
    </ListBox >
