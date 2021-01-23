    <StackPanel>
        <TextBox Name="VehicalNo_Text" Height="23" Width="80" TextWrapping="Wrap"  HorizontalAlignment="Left" >
            <TextBox.Triggers>
                <EventTrigger RoutedEvent="TextBox.MouseDoubleClick">
                    <EventTrigger.Actions>
                        <BeginStoryboard>
                            <Storyboard>
                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="Notification" Storyboard.TargetProperty="Content">
                                    <DiscreteObjectKeyFrame KeyTime="0:0:0" Value="{Binding ElementName=VehicalNo_Text,Path=Text}"></DiscreteObjectKeyFrame>
                                </ObjectAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger.Actions>
                </EventTrigger>
            </TextBox.Triggers>
        </TextBox>
        <Label Name="Notification" Content="change content"/>
    </StackPanel>
