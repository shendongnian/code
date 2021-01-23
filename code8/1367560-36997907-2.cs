    <Style x:Key="ChangeContentOnMouseOverWithAnimationWhenPressed" TargetType="Button" BasedOn="{StaticResource {x:Type Button}}">
            <Setter Property="Background" Value="{StaticResource RedButtonBackGround}"/>
            <Setter Property="Foreground" Value="Yellow"></Setter>
            <Setter Property="Width" Value="50"></Setter>
            <Setter Property="Height" Value="50"></Setter>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Grid x:Name="LayoutRoot" RenderTransformOrigin="0.5 0.5">
                            <Grid.RenderTransform>
                                <ScaleTransform></ScaleTransform>
                            </Grid.RenderTransform>
                            <Border x:Name="MyBorder" CornerRadius="5" Background="{TemplateBinding Background}" BorderThickness="1"/>
                            <Border x:Name="RectangleVisibleOnMouseMove" Opacity="0" CornerRadius="5" Background="{StaticResource KoalaImageBrushKey}" BorderThickness="1"/>
                            <Border x:Name="RectangleVisibleOnCklick" Opacity="0" CornerRadius="5" Background="Blue" BorderThickness="1"/>
                            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <EventTrigger RoutedEvent="Button.MouseEnter">
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="RectangleVisibleOnMouseMove" 
                                       Storyboard.TargetProperty="(FrameworkElement.Opacity)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="0.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="1.0" />
                                        </DoubleAnimationUsingKeyFrames>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="MyBorder" 
                                       Storyboard.TargetProperty="(FrameworkElement.Opacity)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="1.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="0.0" />
                                        </DoubleAnimationUsingKeyFrames>
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger>
                            <EventTrigger RoutedEvent="Button.MouseLeave">
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="RectangleVisibleOnMouseMove" 
                                       Storyboard.TargetProperty="(FrameworkElement.Opacity)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="1.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="0.0" />
                                        </DoubleAnimationUsingKeyFrames>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="MyBorder" 
                                       Storyboard.TargetProperty="(FrameworkElement.Opacity)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="0.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="1.0" />
                                        </DoubleAnimationUsingKeyFrames>
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger>
                            <EventTrigger RoutedEvent="Button.PreviewMouseDown">
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="LayoutRoot" 
                                       Storyboard.TargetProperty="(Grid.RenderTransform).(ScaleTransform.ScaleX)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="1.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:0.10" Value="0.8" />
                                            <!--<EasingDoubleKeyFrame KeyTime="0:0:0.15" Value="1.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:0.20" Value="1.0" />-->
                                        </DoubleAnimationUsingKeyFrames>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="LayoutRoot" 
                                       Storyboard.TargetProperty="(Grid.RenderTransform).(ScaleTransform.ScaleY)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="1.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:0.10" Value="0.8" />
                                            <!--<EasingDoubleKeyFrame KeyTime="0:0:0.15" Value="1.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:0.20" Value="1.0" />-->
                                        </DoubleAnimationUsingKeyFrames>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="RectangleVisibleOnCklick" 
                                       Storyboard.TargetProperty="(FrameworkElement.Opacity)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="0.0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="0.1" />
                                        </DoubleAnimationUsingKeyFrames>
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger>
                            <EventTrigger RoutedEvent="Button.PreviewMouseUp">
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="LayoutRoot" 
                                       Storyboard.TargetProperty="(Grid.RenderTransform).(ScaleTransform.ScaleX)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="0.8" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:0.10" Value="1.0" />
                                        </DoubleAnimationUsingKeyFrames>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="LayoutRoot" 
                                       Storyboard.TargetProperty="(Grid.RenderTransform).(ScaleTransform.ScaleY)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="0.8" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:0.10" Value="1.0" />
                                        </DoubleAnimationUsingKeyFrames>
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="RectangleVisibleOnCklick" 
                                       Storyboard.TargetProperty="(FrameworkElement.Opacity)">
                                            <EasingDoubleKeyFrame KeyTime="0:0:0" Value="0.1" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="0.0" />
                                        </DoubleAnimationUsingKeyFrames>
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Style.Triggers>
                <Trigger Property="IsPressed" Value="True">
                    <Setter Property="Foreground" Value="White"></Setter>
                </Trigger>
                <Trigger Property="IsPressed" Value="False">
                    <Setter Property="Foreground" Value="Yellow"></Setter>
                </Trigger>
            </Style.Triggers>
        </Style>
