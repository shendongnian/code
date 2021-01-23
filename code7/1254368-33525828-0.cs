    <Application.Resources>
        <Storyboard x:Key="SB_Height" x:Shared="False">
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.Height)"
                    Storyboard.TargetName="{DynamicResource AnimationTarget}">
                <EasingDoubleKeyFrame KeyTime="0:0:1" Value="90">
                    <EasingDoubleKeyFrame.EasingFunction>
                        <CircleEase EasingMode="EaseOut" />
                    </EasingDoubleKeyFrame.EasingFunction>
                </EasingDoubleKeyFrame>
            </DoubleAnimationUsingKeyFrames>
        </Storyboard>
    </Application.Resources>
    <Button Name="mybutton" Content="Test" Height="20">
        <Button.Triggers>
            <EventTrigger RoutedEvent="Button.Click">
                <BeginStoryboard Storyboard="{StaticResource SB_Height}"/>
            </EventTrigger>
        </Button.Triggers>
    </Button>
