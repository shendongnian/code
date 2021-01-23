    <Style.Triggers>
        <MultiTrigger>
            <MultiTrigger.Conditions>
                <Condition Property="IsSelected" Value="False"/>
                <Condition Property="IsMouseOver" Value="True"/>
            </MultiTrigger.Conditions>
            <MultiTrigger.EnterActions>
                <BeginStoryboard>
                    <Storyboard>
                        <ColorAnimation To="#E1E1E1"
                                        Storyboard.TargetProperty="(TabItem.Background).(SolidColorBrush.Color)"
                                        Duration="00:00:00.3"/>
                    </Storyboard>
                </BeginStoryboard>
            </MultiTrigger.EnterActions>
            <MultiTrigger.ExitActions>
                <BeginStoryboard>
                    <Storyboard>
                        <ColorAnimation Storyboard.TargetProperty="(TabItem.Background).(SolidColorBrush.Color)"
                                        Duration="00:00:00.3"/>
                    </Storyboard>
                </BeginStoryboard>
            </MultiTrigger.ExitActions>
        </MultiTrigger>
        <Trigger Property="IsSelected" Value="True">
            <Setter Property="Background" Value="#3090C7" />
            <Setter Property="Foreground" Value="#F2F2F2" />
            <Setter Property="BorderThickness" Value="0" />
        </Trigger>
    </Style.Triggers>
