     <Grid>
        <Rectangle Fill="Black"   Height="5" Width="200" HorizontalAlignment="Center" VerticalAlignment="Center" >
            <Rectangle.RenderTransform>
                <RotateTransform x:Name="hrHand" />
            </Rectangle.RenderTransform>
            <Rectangle.Triggers>
                <EventTrigger RoutedEvent="Loaded">
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation  Duration="12:0:0" To="360" RepeatBehavior="Forever" Storyboard.TargetName="hrHand" Storyboard.TargetProperty="Angle"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </Rectangle.Triggers>
        </Rectangle>
        <Rectangle Fill="Black" Height="2" Width="200" HorizontalAlignment="Center" VerticalAlignment="Center" >
            <Rectangle.RenderTransform>
                <RotateTransform x:Name="minHand" />
            </Rectangle.RenderTransform>
            <Rectangle.Triggers>
                <EventTrigger RoutedEvent="Loaded">
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation  Duration="1:0:0" To="360" RepeatBehavior="Forever"  Storyboard.TargetName="minHand" Storyboard.TargetProperty="Angle"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </Rectangle.Triggers>
        </Rectangle>
        <Rectangle Fill="Red"    Height="1" Width="200"   HorizontalAlignment="Center" VerticalAlignment="Center" >
            <Rectangle.RenderTransform>
                <RotateTransform x:Name="sechand"/>
            </Rectangle.RenderTransform>
            <Rectangle.Triggers>
                <EventTrigger RoutedEvent="Loaded">
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation  Duration="0:1:0" RepeatBehavior="Forever" To="360"  Storyboard.TargetName="sechand" Storyboard.TargetProperty="Angle"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </Rectangle.Triggers>
        </Rectangle>
    </Grid>
