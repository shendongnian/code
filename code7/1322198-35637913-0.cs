    <Style TargetType="TextBlock">
        <Style.Triggers>
            <EventTrigger RoutedEvent="MouseEnter">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation Duration="0:0:0.300" Storyboard.TargetProperty="FontSize" To="28" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
            <EventTrigger RoutedEvent="MouseLeave">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation Duration="0:0:0.800" Storyboard.TargetProperty="FontSize" To="18" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
         </Style.Triggers>
      </Style>
