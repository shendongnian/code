    <Style TargetType="Button">
        <Setter Property="BorderThickness" Value="1" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <Border Name="border" Background="Transparent" BorderThickness="{TemplateBinding BorderThickness}" BorderBrush="Black">
                        <ContentPresenter/>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        <Style.Triggers>
            <EventTrigger RoutedEvent="Click">
                <EventTrigger.Actions>
                    <BeginStoryboard>
                        <Storyboard>
                            <ThicknessAnimationUsingKeyFrames Storyboard.TargetProperty="BorderThickness">
                                <DiscreteThicknessKeyFrame Value="10" KeyTime="0" />
                            </ThicknessAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger.Actions>
            </EventTrigger>
        </Style.Triggers>
    </Style>
