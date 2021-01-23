    <ItemsControl ItemsSource="{Binding MyItemSource}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Expander IsExpanded="{Binding IsSelected}">
                    <Expander.Header>
                        <Button Command="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ItemsControl}, Path=DataContext.SelectItem}"
                                CommandParameter="{Binding"}>Click Me</Button>
                    </Expander.Header>
                    <!-- content here -->
                </Expander>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
