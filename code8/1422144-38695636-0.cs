     <Style TargetType="{x:Type Button}">
                <Style.Resources>
                    <Storyboard x:Key="Storyboard" Storyboard.TargetProperty="(Background).(SolidColorBrush.Color)">
                        <ColorAnimationUsingKeyFrames  Duration="0:0:5" >
                            <DiscreteColorKeyFrame KeyTime="0:0:1" Value="Black"></DiscreteColorKeyFrame>
                            <DiscreteColorKeyFrame KeyTime="0:0:2" Value="Red"></DiscreteColorKeyFrame>
                            <DiscreteColorKeyFrame KeyTime="0:0:3" Value="Black"></DiscreteColorKeyFrame>
                            <DiscreteColorKeyFrame KeyTime="0:0:4" Value="Red"></DiscreteColorKeyFrame>
                            <DiscreteColorKeyFrame KeyTime="0:0:5" Value="Black"></DiscreteColorKeyFrame>
                        </ColorAnimationUsingKeyFrames>
                    </Storyboard>
                </Style.Resources>
                <Style.Triggers>
                    <EventTrigger RoutedEvent="Click">
                        <EventTrigger.Actions>
                            <BeginStoryboard Name="flash" Storyboard="{StaticResource Storyboard}"/>
                        </EventTrigger.Actions>
                    </EventTrigger>
                </Style.Triggers>
            </Style>
