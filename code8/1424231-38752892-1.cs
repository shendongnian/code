        <Border x:Name="border" Width="200" Height="82" Canvas.Left="098" Canvas.Top="93" BorderThickness="6,8,7,8" 
                BorderBrush="Black" Background="LightBlue">
            <Border.Triggers>
                <EventTrigger RoutedEvent="Border.MouseLeftButtonUp">
                    <BeginStoryboard>
                        <Storyboard>
                            <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.IsEnabled)">
                                <DiscreteBooleanKeyFrame KeyTime="0" Value="False"/>
                                <DiscreteBooleanKeyFrame KeyTime="0:0:0.5" Value="True"/>
                            </BooleanAnimationUsingKeyFrames>
                            <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Panel.Background).(SolidColorBrush.Color)">
                                <DiscreteColorKeyFrame KeyTime="0:0:0" Value="{Binding IsLeft, Converter={StaticResource IsLeftToColorConverter}}"/>
                                <DiscreteColorKeyFrame KeyTime="0:0:0.5" Value="LightBlue"/>
                            </ColorAnimationUsingKeyFrames>
                            <h:CommandFakeAnimation Duration="0:0:0" Command="{Binding Path=FakeAnimationCommand, Mode=OneWay}"
                                        Storyboard.TargetProperty="Opacity" />
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </Border.Triggers>
            <TextBlock Text="{Binding CountModel.Word}"/>
        </Border>
