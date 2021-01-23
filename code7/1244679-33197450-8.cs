        <Grid>
        <TreeView x:Name="TreeViewTest" ItemsSource="{Binding Items}" TreeViewItem.Expanded="TreeViewTest_OnExpanded">
            <TreeView.ItemTemplate>
                <HierarchicalDataTemplate DataType="{x:Type soTreeViewHelpAttempt:TreeObject}" 
                                          ItemsSource="{Binding Children, Mode=OneTime}">
                    <HierarchicalDataTemplate.ItemTemplate>
                        <DataTemplate>
                            <StackPanel>
                                <Label Content="{Binding }" />
                            </StackPanel>
                        </DataTemplate>
                    </HierarchicalDataTemplate.ItemTemplate>
                    <StackPanel>
                        <Label Content="{Binding Title, Mode=OneTime}" />
                    </StackPanel>
                </HierarchicalDataTemplate>
            </TreeView.ItemTemplate>
            <i:Interaction.Behaviors>
                <soTreeViewHelpAttempt:TreeViewItemExpandBehavior OnExpandedAction="{Binding OnExpandedActionInViewModel}"/>
            </i:Interaction.Behaviors>
        </TreeView></Grid>
