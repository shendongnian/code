    <DockPanel Background="#151515" LastChildFill="True" Visibility="Visible" Opacity="0" Name="TopMenuArea"  Height="55">
        <DockPanel.Triggers>
            <EventTrigger RoutedEvent="DockPanel.MouseEnter">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation Storyboard.TargetProperty="Opacity" Storyboard.TargetName="TopMenuArea"
                                From="0.0" To="1.0" Duration="0:0:1"></DoubleAnimation>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
            <EventTrigger RoutedEvent="DockPanel.MouseLeave">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation Storyboard.TargetProperty="Opacity" Storyboard.TargetName="TopMenuArea"
                                From="1.0" To="0" Duration="0:0:1"></DoubleAnimation>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </DockPanel.Triggers>
    </DockPanel>
