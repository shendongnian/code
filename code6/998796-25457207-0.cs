     <Button Style="{StaticResource {x:Static ToolBar.ButtonStyleKey}}" Content="" HorizontalAlignment="Right" Margin="0,0,0.2,0" VerticalAlignment="Bottom" Width="50" Height="100" Grid.Column="1" Click="Next_Click">
       <Button.Template>
            <ControlTemplate>
                <ControlTemplate.Triggers>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Setter Property="Background" TargetName="root">
                            <Setter.Value>
                                <ImageBrush ImageSource="nextGreen.png" />
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </ControlTemplate.Triggers>
                <StackPanel x:Name="root">
                    <StackPanel.Background>
                        <ImageBrush ImageSource="Nextbutton.png"/>
                    </StackPanel.Background>
                </StackPanel>
            </ControlTemplate>
        </Button.Template>
    </Button>
