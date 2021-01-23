    <Style x:Key="buttonSmiley" TargetType="{x:Type Button}">
        <Style.Resources>
            <Storyboard x:Key="OnVisibleStoryboard">
                <DoubleAnimationUsingKeyFrames Duration="0:0:2.75" Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.Y)" >
                    <LinearDoubleKeyFrame Value="75" KeyTime="0:0:0"/>
                    <SplineDoubleKeyFrame Value="25" KeyTime="0:0:0.75" KeySpline="0, 0, 0.5, 0"/>
                    <LinearDoubleKeyFrame Value="-25" KeyTime="0:0:1.2"/>
                    <SplineDoubleKeyFrame Value="200" KeyTime="0:0:2.25" KeySpline="0, 0, 0, 0.5"/>
                    <LinearDoubleKeyFrame Value="175" KeyTime="0:0:2.4" />
                    <SplineDoubleKeyFrame Value="150" KeyTime="0:0:2.75" KeySpline="0, 0, 0, 0.5"/>
                </DoubleAnimationUsingKeyFrames>
                <DoubleAnimationUsingKeyFrames Duration="0:0:5.5" Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[1].(ScaleTransform.ScaleX)" >
                    <LinearDoubleKeyFrame Value="0.01" KeyTime="0:0:0"/>
                    <LinearDoubleKeyFrame Value="1" KeyTime="0:0:1.25"/>
                    <LinearDoubleKeyFrame Value="1" KeyTime="0:0:2.05"/>
                    <LinearDoubleKeyFrame Value="1.15" KeyTime="0:0:2.15"/>
                    <LinearDoubleKeyFrame Value="1" KeyTime="0:0:2.4"/>
                    <LinearDoubleKeyFrame Value="1" KeyTime="0:0:2.75"/>
                </DoubleAnimationUsingKeyFrames>
                <DoubleAnimationUsingKeyFrames Duration="0:0:5.5" Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[1].(ScaleTransform.ScaleY)" >
                    <LinearDoubleKeyFrame Value="0.01" KeyTime="0:0:0"/>
                    <LinearDoubleKeyFrame Value="1" KeyTime="0:0:1.25"/>
                    <LinearDoubleKeyFrame Value="1" KeyTime="0:0:2.05"/>
                    <LinearDoubleKeyFrame Value="0.75" KeyTime="0:0:2.2"/>
                    <LinearDoubleKeyFrame Value="1" KeyTime="0:0:2.4"/>
                    <LinearDoubleKeyFrame Value="1" KeyTime="0:0:2.75"/>
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
        </Style.Resources>
        <Style.Triggers>
            <Trigger Property="Visibility" Value="Visible">
                <Trigger.EnterActions>
                    <RemoveStoryboard BeginStoryboardName="OnLoadStoryboard_BeginStoryboard"/>
                    <BeginStoryboard x:Name="OnVisibleStoryboard_BeginStoryboard" Storyboard="{StaticResource OnVisibleStoryboard}"/>
                </Trigger.EnterActions>
            </Trigger>
            <EventTrigger RoutedEvent="Button.Loaded">
                <RemoveStoryboard BeginStoryboardName="OnVisibleStoryboard_BeginStoryboard"/>
                <BeginStoryboard x:Name="OnLoadStoryboard_BeginStoryboard" Storyboard="{StaticResource OnVisibleStoryboard}"/>
            </EventTrigger>
        </Style.Triggers>
        <Setter Property="ContentTemplate">
            <Setter.Value>
                <DataTemplate>
                    <Canvas Margin="-35,-35,0,0">
                        <Ellipse Canvas.Left="10" Canvas.Top="10" Width="50" Height="50" Stroke="Blue" StrokeThickness="2" Fill="#FFD8CF15" />
                        <Ellipse Canvas.Left="18" Canvas.Top="12" Width="33" Height="15">
                            <Ellipse.Fill>
                                <LinearGradientBrush StartPoint="0.45,0" EndPoint="0.5, 0.9">
                                    <GradientStop Offset="0.2" Color="DarkMagenta" />
                                    <GradientStop Offset="0.7" Color="Transparent" />
                                </LinearGradientBrush>
                            </Ellipse.Fill>
                        </Ellipse>
                        <Ellipse Canvas.Left="17" Canvas.Top="25" Width="10" Height="10" Stroke="Blue" StrokeThickness="2" Fill="White" />
                        <Ellipse Canvas.Left="20" Canvas.Top="28" Width="3" Height="3" Fill="Black" />
                        <Ellipse Canvas.Left="34" Canvas.Top="25" Width="10" Height="10" Stroke="Blue" StrokeThickness="2" Fill="White" />
                        <Ellipse Canvas.Left="37" Canvas.Top="28" Width="3" Height="3" Fill="Black" />
                        <Path Name="mouth" Stroke="Blue" StrokeThickness="2" Data="M 20,43 Q 27,53 40,44" />
                    </Canvas>
                </DataTemplate>
            </Setter.Value>
        </Setter>
        <Setter Property="RenderTransform">
            <Setter.Value>
                <TransformGroup>
                    <TranslateTransform />
                    <ScaleTransform />
                </TransformGroup>
            </Setter.Value>
        </Setter>
    </Style>
