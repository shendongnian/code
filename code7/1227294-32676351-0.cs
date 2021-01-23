    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="10*" />
            <ColumnDefinition Width="90*" />
        </Grid.ColumnDefinitions>
        <Ellipse x:Name="checkButton" Grid.Column="0" Stroke="Black" Fill="AliceBlue">
            <Ellipse.Style>
                <Style TargetType="{x:Type Ellipse}">
                    <Style.Triggers>
                        <EventTrigger RoutedEvent="MouseEnter">
                            <EventTrigger.Actions>
                                <BeginStoryboard>
                                    <Storyboard>
                                        <ColorAnimation Duration="0:0:0" 
                                                        Storyboard.TargetProperty="(Ellipse.Stroke).(SolidColorBrush.Color)" 
                                                        To="Red" AutoReverse="False"/>
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger.Actions>
                        </EventTrigger>
                        <EventTrigger RoutedEvent="MouseLeave">
                            <EventTrigger.Actions>
                                <BeginStoryboard>
                                    <Storyboard >
                                        <ColorAnimation Duration="0:0:0"
                                                        Storyboard.TargetProperty="(Ellipse.Stroke).(SolidColorBrush.Color)"
                                                        To="Black"/>
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger.Actions>
                        </EventTrigger>
                    </Style.Triggers>
                </Style>
            </Ellipse.Style>
        </Ellipse>
        <TextBlock x:Name="txtContent" Grid.Column="1" FontWeight="Bold" VerticalAlignment="Center" FontSize="14" HorizontalAlignment="Center" TextAlignment="Center">
        <ContentPresenter />
        </TextBlock>
    </Grid>
