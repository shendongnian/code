    <UserControl xmlns:namespaceA="clr-namespace:MyProj.Models.ObjectANamespace"
                 xmlns:namespaceB="clr-namespace:MyProj.Models.ObjectBNamespace"
                 xmlns:namespaceC="clr-namespace:MyProj.Models.ObjectCNamespace" >
        <ListBox ItemsSource="{Binding ObjectACollection}">
            <ListBox.ItemTemplate>
                <DataTemplate DataType="namespaceA:ObjectA">
                    <StackPanel Orientation="Horizontal">
                        <ListBox ItemsSource="{Binding ObjectBCollection}">
                            <ListBox.ItemTemplate>
                                <DataTemplate DataType="namespaceB:ObjectB">
                                    <!-- Template for these items -->
                                </DataTemplate>
                            </ListBox.ItemTemplate>
                        </ListBox>
                        <ListBox ItemsSource="{Binding ObjectCCollection}">
                            <ListBox.ItemTemplate>
                                <DataTemplate DataType="namespaceC:ObjectC">
                                    <!-- Template for these items -->
                                </DataTemplate>
                            </ListBox.ItemTemplate>
                        </ListBox>
                    </StackPanel>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </UserControl>
