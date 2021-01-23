    <Button Content="Content" Background="Red">
            <Button.Triggers>
                <EventTrigger RoutedEvent="MouseEnter">
                    <BeginStoryboard>
                        <Storyboard>
                            <ColorAnimation Storyboard.TargetProperty="(Button.Background).(SolidColorBrush.Color)" To="CadetBlue"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </Button.Triggers>
        </Button>
