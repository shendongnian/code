    <ContextMenu ItemsSource="{Binding ContextItems}">
        <ContextMenu.ItemContainerStyle>
            <Style TargetType="MenuItem">
                <Setter Property="Header" Value="{Binding Text}" />
                <Setter Property="Command" Value="{Binding Command}" />
            </Style>
        </ContextMenu.ItemContainerStyle>
    </ContextMenu>
