    <TreeView.ItemContainerStyle>
        <Style TargetType="{x:Type TreeViewItem}">
            <Setter Property="Tag" Value="{Binding RelativeSource={RelativeSource AncestorType=TreeView}, Path=DataContext}"></Setter>
            <Setter Property="ContextMenu">
                <Setter.Value>
                    <ContextMenu DataContext="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                        <MenuItem Header="Center On" Command="{Binding CenterOnCommand}" />
                    </ContextMenu>
                </Setter.Value>
            </Setter>
        </Style>
    </TreeView.ItemContainerStyle>
