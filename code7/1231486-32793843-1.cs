    <MenuItem Header="_Theme" ItemsSource="{Binding Themes}">
        <MenuItem.ItemTemplate>
            <DataTemplate>
                <MenuItem Header="{Binding Name}" IsChecked="{Binding Checked}" IsCheckable="True"/>
            </DataTemplate>
        </MenuItem.ItemTemplate>
    </MenuItem>
