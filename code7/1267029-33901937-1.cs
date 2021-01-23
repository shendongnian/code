    <ItemsControl ItemsSource="{Binding MyCollectionOfSensorData}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <CheckBox Checked="{Binding IsChecked}" />
                    <TextBox Text="{Binding Text}" Enabled="{Binding IsChecked}" />
                </StackPanel>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
