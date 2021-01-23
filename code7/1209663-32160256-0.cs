    <Menu AlternationCount="2">
        <Menu.ItemContainerStyle>
            <Style TargetType="MenuItem">
                <Style.Triggers>
                    <Trigger Property="ItemsControl.AlternationIndex" Value="0">
                        <Setter Property="Background"  Value="Red"></Setter>
                    </Trigger>
                    <Trigger Property="ItemsControl.AlternationIndex" Value="1">
                        <Setter Property="Background" Value="Blue"></Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Menu.ItemContainerStyle>
            
        <MenuItem Header="qwe" />
        <MenuItem Header="qwe" />
        <MenuItem Header="qwe" />
        <MenuItem Header="qwe" />
        <MenuItem Header="qwe" />
    </Menu>
