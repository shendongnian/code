    <ContextMenu ItemsSource="{Binding MenuItems}">
        <ContextMenu.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding SubItems}">
                <MenuItem Header="{Binding MainItemName}"/>
                <HierarchicalDataTemplate.ItemTemplate>
                    <DataTemplate>
                        <MenuItem Header="{Binding Name}"/>
                    </DataTemplate>
                </HierarchicalDataTemplate.ItemTemplate>
            </HierarchicalDataTemplate>
        </ContextMenu.ItemTemplate>
    </ContextMenu>
