    <TextBlock x:Name="tbMessage" Text="{Binding Path=StatusBarText, NotifyOnTargetUpdated=True}">
        <TextBlock.Triggers>
            <EventTrigger RoutedEvent="Binding.TargetUpdated">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation Storyboard.TargetProperty="Opacity" Duration="0:0:0" To="1.0" />
                        <DoubleAnimation Storyboard.TargetProperty="Opacity" Duration="0:0:2" From="1.0" To="0.0" BeginTime="0:0:5" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </TextBlock.Triggers>
    </TextBlock>
