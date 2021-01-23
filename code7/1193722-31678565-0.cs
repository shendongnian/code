    <DataTemplate>
        <StackPanel Orientation="Horizontal">
            <StackPanel.InputBindings>
                <MouseBinding MouseAction="LeftClick"
                              Command="{Binding DataContext.SomeViewModelCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=TreeView}}"
                              CommandParameter="{Binding}"/>
            </StackPanel.InputBindings>
            ...
        </StackPanel>
    </DataTemplate>
