    <ContextMenu>
        <MenuItem Header="Example Menu Item" ItemsSource="{Binding ObservableItems}">
            <MenuItem.ItemContainerStyle>
                <Style TargetType="{x:Type MenuItem}">
                    <Setter Property="Command" Value="{Binding Path=DataContext.ExampleCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ListView}}"/>
                    <Setter Property="CommandParameter" Value="{Binding}"/>
                </Style>
            </MenuItem.ItemContainerStyle>
        </MenuItem>
    </ContextMenu>
