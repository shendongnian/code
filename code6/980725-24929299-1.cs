    <TreeView x:Name="ArticlesTreeView"  AllowDrop="True">
            <TreeView.ItemContainerStyle>
                <Style TargetType="{x:Type TreeViewItem}">
                    <Setter Property="ContextMenuService.ShowOnDisabled" Value="True" />
                    <Setter Property="ContextMenu">
                        <Setter.Value>
                            <ContextMenu>
                                <MenuItem Header="First item">
                                <MenuItem.Style>
                                    <Style TargetType="MenuItem">
                                        <EventSetter Event="Click" Handler="ContextMenu_ContextMenuOpening_1"></EventSetter>
                                    </Style>
                                </MenuItem.Style>
                                </MenuItem>
                            </ContextMenu>
                        </Setter.Value>
                    </Setter>
                </Style>
            </TreeView.ItemContainerStyle>
            <TreeViewItem>
                
            </TreeViewItem>
        </TreeView>
