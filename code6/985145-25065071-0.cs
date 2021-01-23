    <DataTemplate x:Key="Something">
        <StackPanel Name="spSceneThumb" Width="110">
            <Border Name="Border" BorderThickness="1" Background="#FFFCFCFC">
                <StackPanel>
                    ...
                </StackPanel>
                <Border.Resources>
                    <SolidColorBrush x:Key="EventBrush" Color="Red" />
                </Border.Resources>
                <Border.Style>
                    <Style TargetType="{x:Type Border}">
                        <Setter Property="BorderBrush" Value="#FFAAAAFF" />
                        <Style.Triggers>
                            <EventTrigger RoutedEvent="Prefix:YourClassName.YourEventName">
                                <EventTrigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames 
                                                Storyboard.TargetName="Border" 
                                                Storyboard.TargetProperty="BorderBrush">
                                                <DiscreteObjectKeyFrame KeyTime="0:0:0" 
                                                    Value="{StaticResource EventBrush}" />
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </EventTrigger.EnterActions>
                            </EventTrigger>
                        </Style.Triggers>
                    </Style>
                </Border.Style>
            </Border>
        </StackPanel>
    </DataTemplate>
 
