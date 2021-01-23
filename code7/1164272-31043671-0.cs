    <TreeView BorderThickness="0" ItemsSource="{Binding processes}">
        <TreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding subProcesses}" >
                <Grid>
                    //Number of columns
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="2*"/>
                    </Grid.ColumnDefinitions>
                    //Controls to use in the treeview grid
                    <TextBlock Text="{Binding procesId}" Grid.Column="0"/>
                    <TextBlock Text="{Binding procesName}" Grid.Column="1"/>
                </Grid>
            </HierarchicalDataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
