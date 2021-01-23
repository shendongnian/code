    <ListView ItemsSource="{Binding MyLocations}" SelectedItem="{Binding MySelectedLocation}" SelectionMode="Single">
        <ListView.ItemTemplate>
            <DataTemplate>
                <ToggleButton IsChecked="{Binding IsSelected, RelativeSource={RelativeSource AncestorType=ListViewItem}}" Content="{Binding}" />
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
