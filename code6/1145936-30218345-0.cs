     <TreeView Name="SymbolsTreeView" ItemsSource="{Binding Items}">
            <TreeView.Resources>
                
                <HierarchicalDataTemplate DataType="{x:Type local:Folder}" ItemsSource="{Binding Items}">
                    <Grid Background="Red">
                            <Grid.ContextMenu>
                            <ContextMenu>
                            </ContextMenu>
                        </Grid.ContextMenu>
                        <TextBlock Text="{Binding Name}"/>
                    </Grid>
                </HierarchicalDataTemplate>
                
                <HierarchicalDataTemplate DataType="{x:Type local:Item}" ItemsSource="{Binding Items}">
                    <Grid >
                        <TextBlock Text="{Binding Name}"/>
                    </Grid>
                </HierarchicalDataTemplate>
                
            </TreeView.Resources>
        </TreeView>
   
