    <Label Content="Hello">
        <Label.Triggers>
            <EventTrigger RoutedEvent="Loaded">
                <EventTrigger.Actions>
                    <BeginStoryboard>
                        <Storyboard
                            RepeatBehavior="Forever" 
                            Storyboard.TargetProperty="Foreground.Color">
                            <ColorAnimation From="Black" To="Blue" Duration="0:0:1"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger.Actions>
            </EventTrigger>
        </Label.Triggers>
    </Label>
