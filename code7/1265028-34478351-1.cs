    <Canvas Margin="482,125,206,10" Background="MediumSeaGreen">
        <Rectangle x:Name="Rect" Fill="#FF030315"  Height="100"  Stroke="Black" Width="42" Canvas.Top="222">
            <Rectangle.Triggers>
                <EventTrigger RoutedEvent="MouseEnter">
                    <EventTrigger.Actions>
                        <BeginStoryboard x:Name="Sb">
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetProperty="(Canvas.Top)" Storyboard.TargetName="Rect" By="-100" Duration="0:0:5"/>
                                <DoubleAnimation Storyboard.TargetProperty="Height" Storyboard.TargetName="Rect" By="100" Duration="0:0:5"/>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger.Actions>
                </EventTrigger>
                <EventTrigger RoutedEvent="MouseLeave">
                    <EventTrigger.Actions>
                        <PauseStoryboard BeginStoryboardName="Sb" />
                    </EventTrigger.Actions>
                </EventTrigger>
    
            </Rectangle.Triggers>
        </Rectangle>
    </Canvas>
    
