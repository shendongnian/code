    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
            
        <Grid.RowDefinitions>
            <RowDefinition Height="*"></RowDefinition>
            <RowDefinition Height="Auto"></RowDefinition>
            <RowDefinition Height="Auto"></RowDefinition>
        </Grid.RowDefinitions>
    
        <ListView ItemsSource="{Binding Contacts}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <CheckBox Content="{Binding Name}" IsChecked="{Binding IsSelected, Mode=TwoWay}"></CheckBox>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    
        <TextBlock Grid.Row="1" Text="{Binding SelectedItemsOutput}"></TextBlock>
        <Button Grid.Row="2" Content="What is checked?" Command="{Binding GoCommand}"></Button>
    </Grid>
