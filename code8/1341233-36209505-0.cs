                    <TreeView Name="BuildTree"
                              ItemsSource="{Binding RootItems}">
                        <TreeView.ItemContainerStyle>
                            <Style TargetType="{x:Type TreeViewItem}">
                                <Setter Property="IsExpanded" Value="{Binding IsExpanded, Mode=TwoWay}" />
                                <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}" />
                                <Setter Property="FontWeight" Value="Normal" />
                                <Style.Triggers>
                                    <Trigger Property="IsSelected" Value="True">
                                        <Setter Property="FontWeight" Value="Bold" />
                                    </Trigger>
                                </Style.Triggers>
                            </Style>
                        </TreeView.ItemContainerStyle>
                        <TreeView.ItemTemplate>
                            <HierarchicalDataTemplate ItemsSource="{Binding Folders}">
                                <TextBlock Text="{Binding Name}" />
                            </HierarchicalDataTemplate>
                        </TreeView.ItemTemplate>
                    </TreeView>
