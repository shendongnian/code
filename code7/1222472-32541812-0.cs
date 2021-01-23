        <ContentControl Name="DockItemsContent" Content="{Binding DockItemsViewModel}">
            <ContentControl.ContentTemplate>
                <DataTemplate>
                    <DockPanel>
                        <Menu>
                            <MenuItem Header="File" ItemsSource="{Binding DockItems}">
                                <MenuItem.ItemTemplate>
                                    <DataTemplate>
                                        <MenuItem Header="{Binding Name}"/>
                                    </DataTemplate>
                                </MenuItem.ItemTemplate>
                            </MenuItem>
                        </Menu>
                    </DockPanel>
                </DataTemplate>
            </ContentControl.ContentTemplate>
        </ContentControl>
