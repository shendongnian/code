        <Menu ItemsSource="{Binding CheckStates}">
            <Menu.ItemTemplate>
                <DataTemplate>
                    <CheckBox IsChecked="{Binding IsChecked}"></CheckBox>
                </DataTemplate>
            </Menu.ItemTemplate>
        </Menu>
