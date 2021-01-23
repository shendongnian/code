           <ListBox.ContextMenu >
                <ContextMenu ItemsSource="{Binding MenuItemDataList}">
                    <ContextMenu.ItemTemplate>
                        <DataTemplate DataType="{x:Type model:MenuItemData}">
                            <MenuItem Header="{Binding Name}" />
                        </DataTemplate>
                    </ContextMenu.ItemTemplate>
                    
                </ContextMenu>
            </ListBox.ContextMenu>
