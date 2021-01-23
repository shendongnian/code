    <ListView.ItemTemplate>
        <DataTemplate>
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto"/>
                    <ColumnDefinition Width="*"/>
                </Grid.ColumnDefinitions>
                    <TextBlock Grid.Column="0" Text="{Binding Index}"/>
                    <TextBlock Grid.Column="1" Text="{Binding Name}"/>
            </Grid>
        </DataTemplate>
    </ListView.ItemTemplate>    
