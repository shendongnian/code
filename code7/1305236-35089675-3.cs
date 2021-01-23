    <ContextMenu ItemsSource="{Binding MenuItems}" >
            <ContextMenu.ItemContainerStyle>
                <Style TargetType="{x:Type MenuItem}" >
                    <Setter Property="Header" Value="{Binding Header}"/>
                    <Setter Property="Command" Value="{Binding Command}" />
                </Style>
            </ContextMenu.ItemContainerStyle>
        </ContextMenu>
