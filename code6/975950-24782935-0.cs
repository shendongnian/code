    <Button Content="Click Me">
        <Button.Triggers>
            <EventTrigger RoutedEvent="FrameworkElement.Loaded">
                <BeginStoryboard Name="OpacityStoryboard">
                    <Storyboard>
                        <DoubleAnimation Storyboard.TargetProperty="(UIElement.Opacity)"
                            From="0" To="1" RepeatBehavior="Forever" AutoReverse="True" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
            <EventTrigger RoutedEvent="UIElement.MouseEnter">
                <PauseStoryboard BeginStoryboardName="OpacityStoryboard" />
            </EventTrigger>
            <EventTrigger RoutedEvent="UIElement.MouseLeave">
                <ResumeStoryboard BeginStoryboardName="OpacityStoryboard" />
            </EventTrigger>
        </Button.Triggers>
    </Button>
