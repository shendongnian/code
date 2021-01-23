    <ResourceDictionary ... 
        xmlns:imaging="clr-namespace:Microsoft.VisualStudio.Imaging;assembly=Microsoft.VisualStudio.Imaging">
    <TreeView Name="tevTemplates" Background="#00000000">
        <TreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Items}">
                <StackPanel Orientation="Horizontal">
                    <imaging:CrispImage Moniker="{Binding Image}" />
                    <TextBlock Text="{Binding Title}" />
                </StackPanel>
            </HierarchicalDataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
