     <Grid x:Name="LayoutRoot">
        <Grid.Resources>
            <Storyboard x:Key="detailsBaloonVisibilityAnimation">
                <DoubleAnimationUsingKeyFrames  Storyboard.TargetProperty="ScaleX" Storyboard.TargetName="scale">
                    <EasingDoubleKeyFrame KeyTime="0:0:0" Value="0">
                        <EasingDoubleKeyFrame.EasingFunction>
                            <ElasticEase EasingMode="EaseOut" Oscillations="2" Springiness="5"/>
                        </EasingDoubleKeyFrame.EasingFunction>
                    </EasingDoubleKeyFrame>
                </DoubleAnimationUsingKeyFrames>
                <DoubleAnimationUsingKeyFrames  Storyboard.TargetProperty="ScaleY" Storyboard.TargetName="scale">
                    <EasingDoubleKeyFrame KeyTime="0:0:0" Value="0">
                        <EasingDoubleKeyFrame.EasingFunction>
                            <ElasticEase EasingMode="EaseOut" Oscillations="2" Springiness="5"/>
                        </EasingDoubleKeyFrame.EasingFunction>
                    </EasingDoubleKeyFrame>
                </DoubleAnimationUsingKeyFrames>
                <DoubleAnimationUsingKeyFrames  Storyboard.TargetProperty="ScaleX" Storyboard.TargetName="scale">
                    <EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="1">
                        <EasingDoubleKeyFrame.EasingFunction>
                            <ElasticEase EasingMode="EaseOut" Oscillations="2" Springiness="5"/>
                        </EasingDoubleKeyFrame.EasingFunction>
                    </EasingDoubleKeyFrame>
                </DoubleAnimationUsingKeyFrames>
                <DoubleAnimationUsingKeyFrames  Storyboard.TargetProperty="ScaleY" Storyboard.TargetName="scale">
                    <EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="1">
                        <EasingDoubleKeyFrame.EasingFunction>
                            <ElasticEase EasingMode="EaseOut" Oscillations="2" Springiness="5"/>
                        </EasingDoubleKeyFrame.EasingFunction>
                    </EasingDoubleKeyFrame>
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
        </Grid.Resources>
        <ListBox x:Name="SwatchListBox" Background="Gray">
            <ListBox.Triggers>
                <EventTrigger SourceName="SwatchListBox" RoutedEvent="Selector.SelectionChanged">
                    <EventTrigger.Actions>
                        <BeginStoryboard  Storyboard="{StaticResource detailsBaloonVisibilityAnimation}"/>
                    </EventTrigger.Actions>
                </EventTrigger>
            </ListBox.Triggers>
            <ListBoxItem>1</ListBoxItem>
            <ListBoxItem>2</ListBoxItem>
            <ListBoxItem>3</ListBoxItem>
        </ListBox>
        <Grid x:Name="detailsBaloon" Background="Red" HorizontalAlignment="Right" Height="230" VerticalAlignment="Top" Width="280" RenderTransformOrigin="0.5,0.5">
            <Grid.RenderTransform>
                <ScaleTransform x:Name="scale"  ScaleX="0" ScaleY="0"/>
            </Grid.RenderTransform>
        </Grid>
    </Grid>
