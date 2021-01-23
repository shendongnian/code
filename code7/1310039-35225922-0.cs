    <Grid>
       <Grid.Triggers>
            <EventTrigger RoutedEvent="Button.Click" SourceName="Button">
                  <EventTrigger.Actions>
                        <BeginStoryboard>
                            <Storyboard>
                                <ObjectAnimationUsingKeyFrames Duration="0" Storyboard.TargetName="label" Storyboard.TargetProperty="Content">
                                    <DiscreteObjectKeyFrame KeyTime="0" Value="Content"/>
                                </ObjectAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                  </EventTrigger.Actions>
            </EventTrigger>
      </Grid.Triggers>
            <DockPanel>
            <Label DockPanel.Dock="Top" x:Name="label">Hi</Label>
            <Button x:Name="Button" DockPanel.Dock="Bottom" Height="50" Width="50">
                
            </Button>
            </DockPanel>
        </Grid>
