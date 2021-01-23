        <TreeView  x:Name="ProjectsTree" >
            <TreeViewItem Header="Projects" 
              ItemsSource="{Binding ProjectsViewModelCollection, Mode=TwoWay}" 
              IsExpanded="True" >
                <TreeViewItem.Resources>
                    <HierarchicalDataTemplate DataType="{x:Type local:Project}"  ItemsSource="{Binding Children}">
                        <TextBlock Text="{Binding Name}"></TextBlock>
                    </HierarchicalDataTemplate>
                </TreeViewItem.Resources>
            </TreeViewItem>
