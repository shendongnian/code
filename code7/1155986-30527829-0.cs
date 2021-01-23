    <ComboBox ItemsSource="{Binding Path=MyListOfObjects}">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="10"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <StackPanel Grid.Column="0" ToolTip="This entry has been made obsolete please select another option" Background="Red" Visibility="{Binding IsObsolete, Converter={StaticResource BooleanToVisibilityConverter}}"/>
                    <TextBlock  Grid.Column="1" Text="{Binding Path=Name}" Margin="2,0,0,0"/>
                </Grid>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
