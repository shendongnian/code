    <Canvas ...>
        <Canvas.Background>
            <ImageBrush .../>
        </Canvas.Background>
        <Canvas.Triggers>
            <EventTrigger RoutedEvent="Loaded">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="Opacity">
                            <EasingDoubleKeyFrame KeyTime="0" Value="0" />
                            <EasingDoubleKeyFrame KeyTime="0:0:1.5" Value="1"/>
                        </DoubleAnimationUsingKeyFrames>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Canvas.Triggers>
    </Canvas>
