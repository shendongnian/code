     <Grid>
        <Grid.Resources>
            <BooleanToVisibilityConverter x:Key="VisibilityConverter" />
            <ContextMenu x:Key="MenuOne" Visibility="{Binding IsFolder,Converter={StaticResource VisibilityConverter}}">
                <MenuItem Header="Add Folder" Command="{Binding AddFolderCommand}"/>
                <MenuItem Header="Add Item" Command="{Binding AddItemCommand}"/>
            </ContextMenu>
        </Grid.Resources>
        <TreeView Name="SymbolsTreeView" ItemsSource="{Binding Items}">
            <TreeView.Resources>
                <HierarchicalDataTemplate DataType="{x:Type local:MyTreeViewItem}" ItemsSource="{Binding Items}">
                    <ContentControl>
                        
                    <TextBlock Text="{Binding Name}"/>
                    </ContentControl>
                </HierarchicalDataTemplate>
                <Style TargetType="TreeViewItem">
                    <Setter Property="ContextMenu" Value="{StaticResource MenuOne}"/>
                    <Setter Property="IsExpanded" Value="True"/>
                </Style>
            </TreeView.Resources>
        </TreeView>
    </Grid>
