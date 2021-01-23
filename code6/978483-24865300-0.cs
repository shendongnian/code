    <Style TargetType="Button">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <Border x:Name="border" ...>
                        ...
                    </Border>
                    <ControlTemplate.Triggers>
                        <EventTrigger RoutedEvent="MouseEnter">
                            <BeginStoryboard>
                                <Storyboard>
                                    <ColorAnimation
                                        To="#b2b2b2" Duration="0:0:1"
                                        Storyboard.TargetName="border" 
                                        Storyboard.TargetProperty="Background.Color"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                        <EventTrigger RoutedEvent="MouseLeave">
                            <BeginStoryboard>
                                <Storyboard>
                                    <ColorAnimation
                                        To="#6d6e6e" Duration="0:0:1"
                                        Storyboard.TargetName="border"
                                        Storyboard.TargetProperty="Background.Color"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        ...
        <Setter Property="Background">
            <Setter.Value>
                <SolidColorBrush Color="#6d6e6e"/>
            </Setter.Value>
        </Setter>
    </Style>
