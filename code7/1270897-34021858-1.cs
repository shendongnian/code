    <Rectangle Name="myRectangle" Width="200" Height="30" Fill="Blue">
        <Rectangle.Triggers>
            <EventTrigger RoutedEvent="Rectangle.MouseDown">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation From="30" To="200" Duration="00:00:3" 
                         Storyboard.TargetName="myRectangle" 
                         Storyboard.TargetProperty="Height">
                            <DoubleAnimation.EasingFunction>
                                <ExponentialEase Exponent="6" EasingMode="EaseOut"/>
                            </DoubleAnimation.EasingFunction>
                        </DoubleAnimation>
    
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Rectangle.Triggers>
    
    </Rectangle>
