    <Grid>
        <Border Width="200"
                Height="200"
                BorderBrush="Black"
                BorderThickness="1"
                CornerRadius="4"
                Background="LightBlue"
                RenderTransformOrigin="0.5,0">
            <Border.RenderTransform>
                <RotateTransform x:Name="transform" />
            </Border.RenderTransform>
            <Border.Effect>
                <DropShadowEffect BlurRadius="20" />
            </Border.Effect>
            <Button VerticalAlignment="Bottom"
                    HorizontalAlignment="Center"
                    Margin="0,0,0,10"
                    Padding="5"
                    Content="Click">
                <Button.Triggers>
                    <EventTrigger RoutedEvent="Button.Click">
                        <BeginStoryboard>
                            <Storyboard FillBehavior="Stop">
                                <DoubleAnimation Storyboard.TargetName="transform"
                                                 Storyboard.TargetProperty="Angle"
                                                 From="5"
                                                 Duration="0:0:0.5">
                                    <DoubleAnimation.EasingFunction>
                                        <ElasticEase EasingMode="EaseOut"
                                                     Oscillations="2"
                                                     Springiness="1" />
                                    </DoubleAnimation.EasingFunction>
                                </DoubleAnimation>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </Button.Triggers>
            </Button>
        </Border>
    </Grid>
