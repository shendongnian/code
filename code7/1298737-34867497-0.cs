     <Style TargetType="{x:Type Button}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <ControlTemplate.Triggers>
                            <EventTrigger RoutedEvent="MouseEnter">
                                <BeginStoryboard>
                                    <Storyboard >
                                        <DoubleAnimation   
                                            Storyboard.TargetName="Border"
                                            Storyboard.TargetProperty="Opacity"
                                            From="0" To="1" Duration="0:0:0.3"/>
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger>
                        </ControlTemplate.Triggers>
                        <Border x:Name="Border" Background="Black"/>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
           
        </Style>
