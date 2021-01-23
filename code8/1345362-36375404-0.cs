    <Style TargetType="{x:Type local:ExplorerControl}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type local:ExplorerControl}">
                        <Border>
                            <TreeView Name="myTreeView">
                                <TreeView.Resources>
                                    <SolidColorBrush x:Key="{x:Static SystemColors.HighlightBrushKey}" Color="#FF003BB0" />
                                </TreeView.Resources>
                                <TreeView.ItemContainerStyle>
                                    <Style TargetType="{x:Type TreeViewItem}">
                                        <Setter Property="IsExpanded" Value="True" />
                                    </Style>
                                </TreeView.ItemContainerStyle>
                                <TreeView.ItemTemplate>
                                    <HierarchicalDataTemplate ItemsSource="{Binding Nodes}">
                                        <StackPanel Orientation="Horizontal"
                                                    Tag="{Binding TemplatedParent,RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type TreeView}}}">                                      
                                            <TextBlock Text="{Binding Name}" VerticalAlignment="Center" />
                                            <StackPanel.ContextMenu>
                                                <ContextMenu>
                                                    <MenuItem x:Name="myTemplate"
                                                              Header="Remove"
                                                              DataContext="{Binding PlacementTarget, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ContextMenu}}}"
                                                              Command="{Binding Path=Tag.RemoveCommand}"
                                                              CommandParameter="{Binding Path=DataContext}">                                    
                                                    </MenuItem>
                                                </ContextMenu>
                                            </StackPanel.ContextMenu>
                                        </StackPanel>
                                    </HierarchicalDataTemplate>
                                </TreeView.ItemTemplate>
                            </TreeView>
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
