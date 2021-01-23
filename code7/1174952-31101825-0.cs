    <ListView ItemsSource="{Binding People}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                    <StackPanel>
                        <TextBlock Text="{Binding Name}" />
                        <TextBlock Text="{Binding Age, StringFormat='Age: {0}'}" />
                    </StackPanel>
                    <StackPanel Grid.Column="1">
                        <TextBlock Text="{Binding Address1}" />
                        <TextBlock Text="{Binding Address2}" />
                    </StackPanel>
                </Grid>                    
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
