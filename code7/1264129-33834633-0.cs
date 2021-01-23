    <ContextMenu ItemsSource="{Binding Actions}">
        <ContextMenu.ItemContainerStyle>
            <Style TargetType="{x:Type MenuItem}" BasedOn="{StaticResource MetroMenuItem}">
                <Setter Property="Header" Value="{Binding Title}"/>
                <Setter Property="ToolTip" Value="{Binding ToolTips}"/>
                <Setter Property="Command" Value="{Binding Command}"/>
                <Setter Property="Icon" Value="{StaticResource Icon}"/>
                <Setter Property="CommandParameter" Value="{Binding CommandParameter}"/>
            </Style>
        </ContextMenu.ItemContainerStyle>
    </ContextMenu>
