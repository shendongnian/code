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
                
                <DataTemplate DataType="{x:Type local:Item}" >
                    <Grid >
                        <TextBlock Text="{Binding Name}"/>
                    </Grid>
                </DataTemplate>
                
            </TreeView.Resources>
        </TreeView>
   
