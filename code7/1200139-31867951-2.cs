    <Button Style="{StaticResource styleBounceAndSquash}">
        <Button.RenderTransform>
            <TransformGroup>
                <ScaleTransform x:Name="aniSquash"/>
                <TranslateTransform x:Name="aniBounce"/>
            </TransformGroup>
        </Button.RenderTransform>
        <Button.Triggers>
            <EventTrigger RoutedEvent="Loaded">
                <BeginStoryboard>
                    <Storyboard SpeedRatio="2.0">
                        <DoubleAnimationUsingKeyFrames Duration="0:0:4.5" Storyboard.TargetName="aniBounce" Storyboard.TargetProperty="Y" RepeatBehavior="Forever">
                            <LinearDoubleKeyFrame Value="120" KeyTime="0:0:0"/>
                            <SplineDoubleKeyFrame Value="260" KeyTime="0:0:2.2" KeySpline="0, 0, 0.5, 0"/>
                            <LinearDoubleKeyFrame Value="260" KeyTime="0:0:2.25"/>
                            <SplineDoubleKeyFrame Value="120" KeyTime="0:0:4.5" KeySpline="0, 0, 0, 0.5"/>
                        </DoubleAnimationUsingKeyFrames>
                        <DoubleAnimationUsingKeyFrames Duration="0:0:4.5" Storyboard.TargetName="aniSquash" Storyboard.TargetProperty="ScaleX" RepeatBehavior="Forever">
                            <LinearDoubleKeyFrame Value="1" KeyTime="0:0:0"/>
                            <LinearDoubleKeyFrame Value="1" KeyTime="0:0:2"/>
                            <LinearDoubleKeyFrame Value="1.3" KeyTime="0:0:2.25"/>
                            <LinearDoubleKeyFrame Value="1" KeyTime="0:0:2.5"/>
                        </DoubleAnimationUsingKeyFrames>
                        <DoubleAnimationUsingKeyFrames Duration="0:0:4.5" Storyboard.TargetName="aniSquash" Storyboard.TargetProperty="ScaleY" RepeatBehavior="Forever">
                            <LinearDoubleKeyFrame Value="1" KeyTime="0:0:0"/>
                            <LinearDoubleKeyFrame Value="1" KeyTime="0:0:2"/>
                            <LinearDoubleKeyFrame Value="0.7" KeyTime="0:0:2.25"/>
                            <LinearDoubleKeyFrame Value="1" KeyTime="0:0:2.5"/>
                        </DoubleAnimationUsingKeyFrames>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Button.Triggers>
    </Button>
